using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;

namespace Engenharia.Candidatos.Application.Facade.Interfaces
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
