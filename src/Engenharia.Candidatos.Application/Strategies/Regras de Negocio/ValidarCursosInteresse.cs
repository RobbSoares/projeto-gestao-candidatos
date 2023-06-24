using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Application.Strategies.Interfaces;
using Engenharia.Candidatos.Domain.Interfaces;

namespace Engenharia.Candidatos.Application.Strategies.Requisito_Funcional
{
    public class ValidarCursosInteresse : IStrategy
    {
        public string Processar(IEntidade entidade)
        {
            if (entidade is Candidato)
            {
                Candidato candidato = (Candidato)entidade;

                if (candidato.CursosInteresses.Count < 1)
                {
                    return "Candidato não pode ter menos de 1 curso de interesse";
                }

            }
            else
            {
                return "Cursos de interesse não podem ser validados pois não é um Candidato!";
            }

            return null;
        }
    }
}
