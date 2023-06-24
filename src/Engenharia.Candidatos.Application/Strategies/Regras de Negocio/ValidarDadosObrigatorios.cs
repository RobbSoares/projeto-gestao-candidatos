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
    public class ValidarDadosObrigatorios : IStrategy
    {
        public string Processar(IEntidade entidade)
        {
            if (entidade is Candidato)
            {
                Candidato candidato = (Candidato)entidade;

                if (String.IsNullOrEmpty(candidato.Nome))
                {
                    return "Candidato não pode ter o nome vazio";
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
