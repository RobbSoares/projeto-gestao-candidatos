using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Domain.Interfaces;

namespace Engenharia.Candidatos.Infra.Data.DAO.Interfaces
{
    public interface IDAO
    {
        void Salvar(IEntidade candidato);
        string Deletar(IEntidade candidato);
        string Atualizar(IEntidade candidato);
        List<IEntidade> Consultar(IEntidade candidato);
    }
}
