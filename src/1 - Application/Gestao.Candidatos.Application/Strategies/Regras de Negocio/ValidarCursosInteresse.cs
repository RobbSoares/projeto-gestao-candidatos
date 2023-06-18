using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Application.Strategies.Interfaces;
using Gestao.Candidatos.Domain.Interfaces;

namespace Gestao.Candidatos.Application.Strategies.Requisito_Funcional
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
