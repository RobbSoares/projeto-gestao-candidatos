using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.API.ViewHelper.Interfaces;
using Gestao.Candidatos.Domain.Entities;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Gestao.Candidatos.API.ViewHelper
{
    public class CandidatoViewHelper : IViewHelper
    {
        public Entidade GetEntidade(Request<Entidade> request)
        {
            String operacao = request.Operacao;
            Candidato candidato = new Candidato();
            Candidato candRequest = request.Entidade as Candidato;

            if (!operacao.Equals("VISUALIZACAO"))
            {
                if (candRequest.Id != null)
                {
                    candidato.Id = candRequest.Id;
                }

                if (candRequest.Nome != null)
                {
                    candidato.Nome = candRequest.Nome;
                }

                if (candRequest.NomePai != null)
                {
                    candidato.NomePai = candRequest.NomePai;
                }

                if (candRequest.NomeMae != null)
                {
                    candidato.NomeMae = candRequest.NomeMae;
                }

                if (candRequest.Endereco != null)
                {
                    candidato.Endereco = candRequest.Endereco;
                }

                if (candRequest.CursosInteresses != null)
                {
                    candidato.CursosInteresses = candRequest.CursosInteresses;
                }
                
                if (candRequest.CursosMatriculados != null)
                {
                    candidato.CursosMatriculados = candRequest.CursosMatriculados;
                }

                if (candRequest.Telefones != null)
                {
                    candidato.Telefones = candRequest.Telefones;
                }

                if (candRequest.DtCadastro != null)
                {
                    candidato.DtCadastro = candRequest.DtCadastro;
                }

                if (candRequest.Email != null)
                {
                    candidato.Email = candRequest.Email;
                }

                if (candRequest.Senha != null)
                {
                    candidato.Senha = candRequest.Senha;
                }

                return candidato;
            }
            else {
                candidato.Id = request.Entidade.Id;
            }

            if (operacao.Equals("CONSULTAR"))
            {
                if (candRequest.Id != null)
                {
                    candidato.Id = candRequest.Id;
                }

                if (candRequest.Email != null)
                {
                    candidato.Email = candRequest.Email;
                }

                if (candRequest.Senha != null)
                {
                    candidato.Senha = candRequest.Senha;
                }
            }
            return candidato;
        }

        public Response SetView(Result resultado, Request<Entidade> request)
        {
            Response response = new();
            try
            {
                String operacao = request.Operacao;
                
                if (resultado.Mensagem == null && operacao.Equals("SALVAR"))
                {
                    resultado.Mensagem = "Produto cadastrado com sucesso!";
                }

                if (resultado.Mensagem == null && operacao.Equals("CONSULTAR"))
                {
                    resultado.Mensagem = "Sucesso!";
                }

                if (resultado.Mensagem == null && operacao.Equals("ALTERAR"))
                {
                    resultado.Mensagem = "Sucesso!";
                }

                if (resultado.Mensagem == null && operacao.Equals("EXCLUIR"))
                {
                    resultado.Mensagem = "Produto excluído com sucesso!";
                }

                
                response.Mensagem = resultado.Mensagem;
                response.StatusCode = resultado.StatusCode;

                if (response.Mensagem != null && response.StatusCode != 400)
                {
                    response.StatusCode = 200;
                    response.Entidades = new Dictionary<string, List<object>>();

                    // Adicione as entidades ao dicionário
                    foreach (IEntidade entidade in resultado.Entidades)
                    {
                        string nomeClasse = entidade.GetType().Name;

                        if (!response.Entidades.ContainsKey(nomeClasse))
                        {
                            response.Entidades[nomeClasse] = new List<object>();
                        }

                        response.Entidades[nomeClasse].Add(entidade);
                    }
                }

                return response;
            }
            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }

            return response;
        }

        public Response SetView(Result resultado)
        {
            throw new NotImplementedException();
        }
    }
}
