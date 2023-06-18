﻿using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Application.Commands
{
    public class VisualizarCommand : AbstractCommand
    {
        public override Result Execute(IEntidade entidade)
        {
            return fachada.Visualizar((Entidade)entidade);
        }
    }
}