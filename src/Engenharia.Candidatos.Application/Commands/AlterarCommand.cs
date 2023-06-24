using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Application.Commands.Interfaces;
using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Application.Commands
{
    public class AlterarCommand : AbstractCommand
    {
        public override Result Execute(IEntidade entidade)
        {
            return fachada.Alterar((Entidade) entidade);
        }
    }
}
