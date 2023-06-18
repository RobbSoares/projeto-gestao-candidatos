using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Application.Commands.Interfaces
{ 
    public interface ICommand
    {
        public Result Execute(IEntidade entidade);
    }
}
