using Engenharia.Gestao.De.Candidatos.Domain;

namespace Gestao.Candidatos.Domain.Interfaces
{
    public interface IDao
    {
        string Salvar(IEntidade candidato);
        string Deletar(IEntidade candidato);
        string Atualizar(IEntidade candidato);
        IEnumerable<IEntidade> Consultar(IEntidade candidato);
    }
}
