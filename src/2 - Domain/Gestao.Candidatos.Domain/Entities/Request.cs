using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Domain.Entities
{
    public class Request<T>
        where T : IEntidade
    {
        public T Entidade { get; set; }
        public string Operacao { get; set; }
    }
}
