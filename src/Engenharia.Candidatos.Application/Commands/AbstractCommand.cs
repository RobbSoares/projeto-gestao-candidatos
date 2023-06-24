using Engenharia.Candidatos.Application.Commands.Interfaces;
using Engenharia.Candidatos.Application.Facade;
using Engenharia.Candidatos.Application.Facade.Interfaces;
using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;

namespace Engenharia.Candidatos.Application.Commands
{
    public abstract class AbstractCommand : ICommand
    {
        protected IFachada fachada = new Fachada();
        public abstract Result Execute(IEntidade entidade);
    }
}
