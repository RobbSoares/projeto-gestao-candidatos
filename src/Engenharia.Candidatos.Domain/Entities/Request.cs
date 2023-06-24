using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Domain.Entities
{
    public class Request<T>
        where T : IEntidade
    {
        public T Entidade { get; set; }
        public string Operacao { get; set; }
    }
}
