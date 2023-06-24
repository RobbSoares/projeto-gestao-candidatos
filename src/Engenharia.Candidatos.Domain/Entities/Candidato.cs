using Engenharia.Candidatos.Domain.Entities;
using Engenharia.Candidatos.Domain;
using System.ComponentModel.DataAnnotations;

namespace Engenharia.Candidatos.Domain
{
    public class Candidato : Entidade
    {
        [Required]
        [StringLength(60, ErrorMessage = "Nome grande demais")]
        public string? Nome { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Nome grande demais")]
        public string? NomePai { get; set; }

        [Required]
        [StringLength(60, ErrorMessage = "Nome grande demais")]
        public string? NomeMae { get; set; }

        [Required]
        public List<Curso>? CursosMatriculados { get; set; }

        [Required]
        public List<Curso>? CursosInteresses { get; set; }

        [Required]
        public List<Telefone>? Telefones { get; set; }

        [Required]
        public Endereco? Endereco { get; set; }

        public Candidato() { }

        public Candidato(string nome, string nomePai, string nomeMae, List<Curso> cursosMatriculados, List<Curso> cursosInteresses, List<Telefone> telefones, Endereco endereco, string email, string senha)
        {
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            CursosMatriculados = cursosMatriculados;
            CursosInteresses = cursosInteresses;
            Telefones = telefones;
            Endereco = endereco;
            Email = email;
            Senha = senha;
        }   
    }
}
