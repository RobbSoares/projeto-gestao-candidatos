using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Application.Strategies.Interfaces;
using Engenharia.Candidatos.Domain.Interfaces;

namespace Engenharia.Candidatos.Application.Strategies.Requisito_Funcional
{
    public class ValidarParentesco : IStrategy
    {
        public string Processar(IEntidade entidade)
        {
            if (entidade is Candidato)
            {
                Candidato candidato = (Candidato)entidade;

                if (String.IsNullOrEmpty(candidato.NomeMae))
                {
                    return "Nome da mãe não pode estar vazio";
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
