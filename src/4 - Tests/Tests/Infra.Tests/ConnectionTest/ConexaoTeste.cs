namespace Tests.Infra.Tests.ConnectionTest
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void DeveConectarAoBancoDeDados()
        {
            var connection = DatabaseConnection.GetConnection();
            Assert.IsNotNull(connection);
        }
    }
}