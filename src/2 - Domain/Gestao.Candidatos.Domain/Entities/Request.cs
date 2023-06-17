using Engenharia.Gestao.De.Candidatos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Domain.Entities
{
    public class Request
    {
        public Entidade Entidade { get; set; }
        public string Operacao { get; set; }
        public string Classe { get; set; }
    }
}
