using Engenharia.Candidatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Application.Strategies.Interfaces
{
    public interface IStrategy
    {
        public string Processar(IEntidade entidade);
    }
}