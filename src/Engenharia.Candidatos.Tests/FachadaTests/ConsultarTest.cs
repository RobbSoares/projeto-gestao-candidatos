using Engenharia.Candidatos.Application.Commands;
using Engenharia.Candidatos.Application.Commands.Interfaces;
using Engenharia.Candidatos.Infra.Data.Utils;

namespace Tests.FachadaTests
{
    public class ConsultarTest
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