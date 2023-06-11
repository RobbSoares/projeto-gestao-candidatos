using MySqlConnector;

namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public static class DatabaseConnection
    {
        public static MySqlConnection GetConnection()
        {
            string _connectionString = "server=127.0.0.1;uid=root;pwd=usbw;database=gestao";
            using var connection = new MySqlConnection(_connectionString);
            return connection;
        }
    }
}

