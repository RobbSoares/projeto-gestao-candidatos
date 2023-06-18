using Gestao.Candidatos.Domain.Interfaces;

namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Entidade: IEntidade
    {
        public int Id { get; set; }
        public DateTime DtCadastro { get; set; }
    }
}
