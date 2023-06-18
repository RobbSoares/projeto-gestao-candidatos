using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Domain.Interfaces;

namespace Gestao.Candidatos.Infra.Data.DAO.Interfaces
{
    public interface IDAO
    {
        void Salvar(IEntidade candidato);
        string Deletar(IEntidade candidato);
        string Atualizar(IEntidade candidato);
        List<IEntidade> Consultar(IEntidade candidato);
    }
}
