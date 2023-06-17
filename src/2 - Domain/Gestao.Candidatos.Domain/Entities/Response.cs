using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Domain.Entities
{
    public class Response
    {
        public string Mensagem { get; set; }
        public Dictionary<string, List<object>> Entidades { get; set; }
        public object Data => new { Mensagem, Entidades };
    }
}
