using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Domain.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Engenharia.Candidatos.Infra.Data.DAO
{
    public class EnderecoDAO : AbstractDAO
    {
        public EnderecoDAO()
        {
        }

        public override string Atualizar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override List<IEntidade> Consultar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override string Deletar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override void Salvar(IEntidade entidade)
        {
            if (_connection == null)
            {
                OpenConnection();
            }

            Endereco end = (Endereco) entidade;
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO enderecos (end_logradouro, end_numero, end_cep, end_cidade, end_estado)  ");
            sql.Append("VALUES (?, ?, ?, ?, ?)");
            
            MySqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), _connection, transaction);
                command.Parameters.AddWithValue("@valor1", end.Logradouro);
                command.Parameters.AddWithValue("@valor2", end.Numero);
                command.Parameters.AddWithValue("@valor3", end.CEP);
                command.Parameters.AddWithValue("@valor4", end.Cidade.Nome);
                command.Parameters.AddWithValue("@valor5", end.Cidade.Estado.Nome);

                command.ExecuteNonQuery();
                end.Id = (int) command.LastInsertedId;

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                // Lidar com a exceção
            }
            
        }
    }
}
