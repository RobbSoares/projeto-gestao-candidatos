using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.InfraTests.CandidatoDAOTests
{
    public class ExcluirTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DeveExcluirCandidato()
        {
            CandidatoDAO candidatoDAO = new CandidatoDAO();
            Candidato candidato = new Candidato();
            candidato.Id = 1;
            candidatoDAO.Deletar(candidato);
        }
    }
}
