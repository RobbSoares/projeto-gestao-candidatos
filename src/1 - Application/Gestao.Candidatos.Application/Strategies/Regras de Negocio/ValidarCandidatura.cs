using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Application.Strategies.Interfaces;
using Gestao.Candidatos.Domain.Interfaces;

namespace Gestao.Candidatos.Application.Strategies.Requisito_Funcional
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
