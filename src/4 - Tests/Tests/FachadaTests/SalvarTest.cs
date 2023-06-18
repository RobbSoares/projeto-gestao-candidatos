using Gestao.Candidatos.Application.Commands;
using Gestao.Candidatos.Application.Commands.Interfaces;
using Gestao.Candidatos.Application.Facade;
using Gestao.Candidatos.Application.Facade.Interfaces;
using Gestao.Candidatos.Infra.Data.Utils;
using System.Text.Json;

namespace Tests.FachadaTests
{
    public class SalvarTest
    {
        private ICommand command = new SalvarCommand();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DeveSalvarEntidade()
        {
            var candidato = new Candidato
            {
                Nome = "Josney",
                NomeMae = "Mãe", 
                NomePai = "Pai",
                CursosInteresses = new List<Curso>
                {
                    new Curso { Nome = "ES III", Descricao = "uma bosta"}
                },
                CursosMatriculados = new List<Curso>
                {
                    new Curso { Nome = "LES", Descricao = "uma bosta"}
                },
                Telefones = new List<Telefone>
                {
                    new Telefone {Numero = "11987654567", TipoTelefone = TipoTelefone.Celular}
                    
                },
                Endereco = new Endereco
                {
                    Cidade = new Cidade { Nome = "SP", Estado = new Estado { Nome = "SP" } },
                    CEP = "32489-987",
                    Logradouro = "RUA ALEATORIA",
                    Numero = 50
                }
            };
            string json = JsonSerializer.Serialize(candidato);
            Console.WriteLine(json);
            var resultado = command.Execute((Candidato)candidato);
            Console.WriteLine(resultado.Mensagem);
           
        }
    }
}