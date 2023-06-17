using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Domain.Interfaces;

namespace Gestao.Candidatos.Domain.Result
{
    public class Result : EntidadeAplicacao
    {
        public string Mensagem { get; set; }
        public List<IEntidade> Entidades { get; set; }
    }
}
