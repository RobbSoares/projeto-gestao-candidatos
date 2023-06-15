using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;

namespace Gestao.Candidatos.Application.Fachada.Interfaces
{

    public interface IFachada
    {
        public Result Salvar(IEntidade entidade);
        public Result Alterar(IEntidade entidade);
        public Result Excluir(IEntidade entidade);
        public Result Consultar(IEntidade entidade);
        public Result Visualizar(IEntidade entidade);
    }
}
