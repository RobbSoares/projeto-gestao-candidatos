namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Telefone : Entidade
    {
        public string Numero { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
    }
}
