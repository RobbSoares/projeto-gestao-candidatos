using Engenharia.Candidatos.Domain.Interfaces;

namespace Engenharia.Candidatos.Domain
{
    public class Entidade: IEntidade
    {
        public int Id { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
