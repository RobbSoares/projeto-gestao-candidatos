namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Candidato : Entidade
    {
        public string Nome { get; set; } 
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public List<Curso> CursosMatriculados { get; set; }
        public List<Curso> CursosInteresses { get; set; }
        public List<Telefone> Telefones { get; set; }
        public Endereco Endereco { get; set; }
        public Candidato() { }

        public Candidato(string nome, string nomePai, string nomeMae, List<Curso> cursosMatriculados, List<Curso> cursosInteresses, List<Telefone> telefones, Endereco endereco)
        {
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            CursosMatriculados = cursosMatriculados;
            CursosInteresses = cursosInteresses;
            Telefones = telefones;
            Endereco = endereco;
        }   
    }
}
