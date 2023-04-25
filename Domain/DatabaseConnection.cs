using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class DatabaseConnection
    {
        private readonly OracleConnection _oracleConnection;

        public DatabaseConnection(string connectionString)
        {
            _oracleConnection = new OracleConnection(connectionString);
        }

        public IEnumerable<T> Query<T>(string sql, object parameters = null)
        {
            using (_oracleConnection)
            {
                _oracleConnection.Open();
                return _oracleConnection.Query<T>(sql, parameters);
            }
        }

        public void Insert(Candidato candidato)
        {
            using (_oracleConnection)
            {
                _oracleConnection.Open();
                string sql = $"INSERT INTO Candidato ({candidato.Id}, {candidato.Nome}";
                _oracleConnection.Execute(sql, candidato);
            }
        }
    }
}

