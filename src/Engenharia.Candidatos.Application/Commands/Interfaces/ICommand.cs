using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Application.Commands.Interfaces
{ 
    public interface ICommand
    {
        public Result Execute(IEntidade entidade);
    }
}
