namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Entity : IEntity
    {
        public int Id { get; set; }
        public DateTime Registro { get; set; } = DateTime.Now;
    }
}
