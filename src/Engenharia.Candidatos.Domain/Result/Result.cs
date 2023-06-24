using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Domain.Interfaces;

namespace Engenharia.Candidatos.Domain.Result
{
    public class Result : EntidadeAplicacao
    {
        public int StatusCode { get; set; }
        public string Mensagem { get; set; }
        public List<IEntidade> Entidades { get; set; }

    }
}
