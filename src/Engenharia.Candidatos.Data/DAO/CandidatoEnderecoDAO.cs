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
    internal class CandidatoEnderecoDAO : AbstractDAO
    {
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

            Candidato candidato = (Candidato) entidade;
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO candidatos_enderecos(cen_can_id, cen_end_id) VALUES (@IdCandidato, @IdEndereco)");

            MySqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                MySqlCommand command = new MySqlCommand(sql.ToString(), _connection, transaction);

                command = new MySqlCommand(sql.ToString(), _connection, transaction);
                command.Parameters.AddWithValue("@IdCandidato", candidato.Id);
                command.Parameters.AddWithValue("@IdEndereco", candidato.Endereco.Id);

                command.ExecuteNonQuery();
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
