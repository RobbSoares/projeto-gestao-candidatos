using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Application.Commands
{
    public class ConsultarCommand : AbstractCommand
    {
        public override Result Execute(IEntidade entidade)
        {
            return fachada.Consultar((Entidade) entidade);
        }
    }
}
