namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Candidato : Entidade
    {
        public string Nome { get; set; } 
        public Filiacao Filiacao { get; set; }
        public List<Curso> CursosMatriculados { get; set; }
        public List<Curso> CursosInteresses { get; set; }
        public int Prioridade { get; set; }
        public List<Telefone> Telefones { get; set; }
        public Endereco Endereco { get; set; }
        public Candidato() { }

        public Candidato(string nome, Filiacao filiacao, List<Curso> cursosMatriculados, List<Curso> cursosInteresses, int prioridade, List<Telefone> telefones, Endereco endereco)
        {
            Nome = nome;
            Filiacao = filiacao;
            CursosMatriculados = cursosMatriculados;
            CursosInteresses = cursosInteresses;
            Prioridade = prioridade;
            Telefones = telefones;
            Endereco = endereco;
        }   
    }
}
