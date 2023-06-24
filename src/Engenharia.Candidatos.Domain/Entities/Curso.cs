namespace Engenharia.Candidatos.Domain
{
    public class Curso : Entidade
    {
        public Curso(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public Curso ()
        {

        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
    }
}
