using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Application.Strategies.Interfaces;
using Engenharia.Candidatos.Domain.Interfaces;

namespace Engenharia.Candidatos.Application.Strategies.Requisito_Funcional
{
    internal class ValidarCandidatura : IStrategy
    {
        public string Processar(IEntidade entidade)
        {
            if (entidade is Candidato){
                Candidato candidato = (Candidato) entidade;

                if (candidato.CursosMatriculados.Count > 3)
                {
                    return "Candidato não pode se candidatar em mais de 3 cursos";
                }

            }else
            {
                return "Curso não pode ser validado pois não é um Candidato!";
            }

            return null;
        }
    }
}
