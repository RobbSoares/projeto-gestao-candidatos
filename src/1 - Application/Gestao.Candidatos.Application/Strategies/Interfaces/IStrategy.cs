﻿using Gestao.Candidatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Application.Strategies.Interfaces
{
    public interface IStrategy
    {
        public string Processar(IEntidade entidade);
    }
}
