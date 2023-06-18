using Gestao.Candidatos.Infra.Data.Utils;

namespace Tests.InfraTests.CandidatoDAOTests
{
    public class SalvarTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DeveSalvarCandidato()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            candidatoDAO.Salvar(null);
        }
    }
}