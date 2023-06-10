namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Telefone : Entity
    {
        public string Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
