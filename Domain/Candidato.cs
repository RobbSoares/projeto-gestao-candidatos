namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class Candidato : Entity
    {

        public string Nome { get; set; } 
        public string Filiacao { get; set; }
        public string CursoMatriculado { get; set; }
        public string CursoInteresse { get; set; }
        public int Prioridade { get; set; }

        public Candidato() { }

        public Candidato(string nome, string filiacao, string cursoMatriculado, string cursoInteresse, int prioridade)
        {
            Nome = nome;
            Filiacao = filiacao;
            CursoMatriculado = cursoMatriculado;
            CursoInteresse = cursoInteresse;
            Prioridade = prioridade;
        }   
    }
}
