using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Infra.Data.Utils;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Infra.Data.DAO
{
    public abstract class AbstractDAO : IDao
    {
        MySqlConnection _connection;

        public AbstractDAO(MySqlConnection connection)
        {
            _connection = connection;
        }

        public abstract string Atualizar(IEntidade entidade);
        public abstract IEnumerable<IEntidade> Consultar(IEntidade entidade);
        public abstract string Deletar(IEntidade entidade);
        public abstract string Salvar(IEntidade entidade);

        protected void OpenConnection()
        {
            try
            {
                if (_connection == null || _connection.State == ConnectionState.Closed)
                    _connection = DatabaseConnection.GetConnection();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
