using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Domain.Interfaces;

namespace Gestao.Candidatos.Infra.Data.DAO.Interfaces
{
    public interface IDao
    {
        string Salvar(IEntidade candidato);
        string Deletar(IEntidade candidato);
        string Atualizar(IEntidade candidato);
        IEnumerable<IEntidade> Consultar(IEntidade candidato);
    }
}
