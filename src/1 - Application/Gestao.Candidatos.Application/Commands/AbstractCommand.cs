using Gestao.Candidatos.Application.Commands.Interfaces;
using Gestao.Candidatos.Application.Facade;
using Gestao.Candidatos.Application.Facade.Interfaces;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;

namespace Gestao.Candidatos.Application.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        protected IFachada fachada = new Fachada();
        public abstract Result Execute(IEntidade entidade);
    }
}
