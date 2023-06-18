using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Application.Commands.Interfaces;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Application.Commands
{
    public class AlterarCommand : AbstractCommand
    {
        public override Result Execute(IEntidade entidade)
        {
            return fachada.Alterar((Entidade) entidade);
        }
    }
}
