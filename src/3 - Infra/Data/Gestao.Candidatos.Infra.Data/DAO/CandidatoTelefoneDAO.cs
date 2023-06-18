using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Domain.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Infra.Data.DAO
{
    public class CandidatoTelefoneDAO : AbstractDAO
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

            Candidato candidato = (Candidato)entidade;
            var telefones = candidato.Telefones;
            StringBuilder sql = new StringBuilder();

            sql.Append("INSERT INTO candidatos_telefones(ctl_can_id, ctl_tel_id) VALUES (@IdCandidato, @IdTelefone)");

            MySqlTransaction transaction = _connection.BeginTransaction();

            try
            {
                foreach (Telefone telefone in telefones)
                {
                    string query = "";

                    using (MySqlCommand command = new MySqlCommand(sql.ToString(), _connection, transaction))
                    {
                        command.Parameters.AddWithValue("@IdCandidato", candidato.Id);
                        command.Parameters.AddWithValue("@IdTelefone", telefone.Id);
                        command.ExecuteNonQuery();
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
