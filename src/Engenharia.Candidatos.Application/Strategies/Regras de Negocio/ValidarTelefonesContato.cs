using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Application.Strategies.Interfaces;
using Engenharia.Candidatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Application.Strategies.Regras_de_Negocio
{
    public class ValidarTelefonesContato : IStrategy
    {

        public string Processar(IEntidade entidade)
        {
            if (entidade is Candidato)
            {
                Candidato candidato = (Candidato)entidade;

                if (candidato.Telefones.Count > 3)
                {
                    return "Candidato não pode ter mais de três numeros para contato";
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
