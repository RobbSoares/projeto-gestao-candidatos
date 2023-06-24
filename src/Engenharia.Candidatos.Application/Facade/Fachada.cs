﻿using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Application.Facade.Interfaces;
using Engenharia.Candidatos.Application.Strategies.Interfaces;
using Engenharia.Candidatos.Application.Strategies.Regras_de_Negocio;
using Engenharia.Candidatos.Application.Strategies.Requisito_Funcional;
using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;
using Engenharia.Candidatos.Infra.Data.DAO;
using Engenharia.Candidatos.Infra.Data.DAO.Interfaces;
using System.Net;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Engenharia.Candidatos.Application.Facade
{
    public class Fachada : IFachada
    {
        private Dictionary<string, IDAO> daos;

        /**
         * Dictionary para conter as regras de negócio de todas as operações por entidade;
         * O valor é um Dictionary de regras de negócio indexado pela operação
         */
        private Dictionary<string, Dictionary<string, List<IStrategy>>> regrasNegocio;
        private Result resultado;

        public Fachada ()
        {

            daos = new Dictionary<string, IDAO>();

            regrasNegocio = new Dictionary<string, Dictionary<string, List<IStrategy>>>();

            CandidatoDAO candidatoDAO = new();

            daos.Add(typeof(Candidato).Name, candidatoDAO);

            ValidarCandidatura validarCandidatura = new();
            ValidarCursosInteresse validarCursosInteresse = new();
            ValidarDadosObrigatorios validarDadosObrigatorios = new();
            ValidarParentesco validarParentesco = new();
            ValidarRegistroCandidato validarRegistroCandidato = new();
            ValidarTelefonesContato validarTelefonesContato = new();

            var regrasNegocioSalvarCandidato = new List<IStrategy>
            {
                validarCandidatura,
                validarCursosInteresse,
                validarDadosObrigatorios,
                validarParentesco,
                validarTelefonesContato
            };

            var regrasNegocioAlterarCandidato = new List<IStrategy>
            { validarRegistroCandidato };

            var regrasNegocioCandidato = new Dictionary<string, List<IStrategy>>
            {
                { "SALVAR", regrasNegocioSalvarCandidato },
                { "ALTERAR", regrasNegocioAlterarCandidato}
            };

            regrasNegocio.Add(typeof(Candidato).Name, regrasNegocioCandidato);

        }

        public Result Alterar(IEntidade entidade)
        {
            var resultado = new Result();

            string nmClasse = entidade.GetType().Name;
            string mensagem = ExecutarRegras(entidade, "ALTERAR");

            if (mensagem == null)
            {
                try
                {
                    if (daos.ContainsKey(nmClasse))
                    {
                        IDAO dao = daos[nmClasse];
                        dao.Atualizar(entidade);
                        List<IEntidade> entidades = new()
                        {
                            (Entidade)entidade
                        };

                        resultado.Entidades = entidades;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                resultado.StatusCode = 400;
                resultado.Mensagem = mensagem;
            }

            return resultado;
        }

        public Result Consultar(IEntidade entidade)
        {
            var resultado = new Result();
            string nmClasse = entidade.GetType().Name;
           
            try
            {
                if (daos.ContainsKey(nmClasse))
                {
                    IDAO dao = daos[nmClasse];
                    var entidades = dao.Consultar(entidade);
                    resultado.Entidades = entidades;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return resultado;
        }

        public Result Excluir(IEntidade entidade)
        {
            var resultado = new Result();
            string nmClasse = entidade.GetType().Name;

            try
            {
                if (daos.ContainsKey(nmClasse))
                {
                    IDAO dao = daos[nmClasse];
                    dao.Deletar(entidade);

                    List<IEntidade> entidades = new()
                    {
                        (Entidade)entidade
                    };

                    resultado.Entidades = entidades;
                }
            }
            catch (Exception ex)
            {
                resultado.StatusCode = 400;
                resultado.Mensagem = "Ocorreu um erro durante a exclusão do candidato";
                Console.WriteLine(ex);
            }
            
            return resultado;
        }

        public Result Salvar(IEntidade entidade)
        {
            var resultado = new Result();
            string nmClasse = entidade.GetType().Name;
            string mensagem = ExecutarRegras(entidade, "SALVAR");
            
            if (mensagem == null)
            {
                try
                {
                    if (daos.ContainsKey(nmClasse))
                    {
                        IDAO dao = daos[nmClasse];
                        dao.Salvar(entidade);
                        List<IEntidade> entidades = new()
                        {
                            (Entidade)entidade
                        };
                        resultado.Entidades = entidades;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            else
            {
                resultado.StatusCode = 400;
                resultado.Mensagem = mensagem;
            }
            

            return resultado;
        }

        public Result Visualizar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        private string ExecutarRegras(IEntidade entidade, string operacao)
        {
            string nmClasse = entidade.GetType().Name;
            StringBuilder msg = new StringBuilder();

            var regrasOperacao = regrasNegocio[nmClasse];


            if (regrasOperacao != null)
            {
                List<IStrategy> regras = regrasOperacao[operacao];

                if (regras != null)
                {
                    foreach (IStrategy strategy in regras)
                    {
                        string m = strategy.Processar(entidade);

                        if (m != null)
                        {
                            msg.Append(m);
                            msg.Append("\n");
                        }
                    }
                }
            }

            if (msg.Length > 0)
                return msg.ToString();
            else
                return null;
        }
    }
}
