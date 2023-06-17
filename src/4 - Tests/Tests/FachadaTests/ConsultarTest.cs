using Gestao.Candidatos.Application.Commands;
using Gestao.Candidatos.Application.Commands.Interfaces;
using Gestao.Candidatos.Infra.Data.Utils;

namespace Tests.FachadaTests
{
    public class GetTest
    {
        private ICommand command = new ConsultarCommand();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DeveConsultarCandidato()
        {
            var candidato = new Candidato
            {
                Id = 1
            };
            var resultado = command.Execute((Candidato) candidato);
            Console.WriteLine(resultado.Mensagem);
        }
    }
}