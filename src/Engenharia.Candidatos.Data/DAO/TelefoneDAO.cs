using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Domain.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engenharia.Candidatos.Infra.Data.DAO
{
    public class TelefoneDAO : AbstractDAO
    {
        public TelefoneDAO()
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

            var candidato = (Candidato) entidade;
            var telefones = candidato.Telefones;

            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO telefones (tel_numero, tel_tipo) VALUES (@numero, @tipo)");

            MySqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                foreach (Telefone telefone in telefones)
                {
                    string query = "";

                    using (MySqlCommand command = new MySqlCommand(sql.ToString(), _connection, transaction))
                    {
                        command.Parameters.AddWithValue("@numero", telefone.Numero);
                        command.Parameters.AddWithValue("@tipo", telefone.TipoTelefone);
                        command.ExecuteNonQuery();

                        telefone.Id = (int)command.LastInsertedId;
                    }
                }

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
