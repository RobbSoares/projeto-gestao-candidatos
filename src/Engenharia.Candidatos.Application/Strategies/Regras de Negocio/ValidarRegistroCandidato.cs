using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Application.Strategies.Interfaces;
using Engenharia.Candidatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Application.Strategies.Requisito_Funcional
{
    public class ValidarRegistroCandidato : IStrategy
    {
        public string Processar(IEntidade entidade)
        {
            if (entidade is Candidato)
            {
                Candidato candidato = (Candidato)entidade;
                DateTime dataAtual = DateTime.Now;
                TimeSpan diferenca = dataAtual.Subtract(candidato.DtCadastro);

                if (diferenca.TotalDays < 365)
                {
                    return "Cadastros com menos de um ano não podem ser atualizados";
                }

            }
            else
            {
                return "Curso não pode ser validado pois não é um Candidato!";
            }

            return null;
        }
    }
}
