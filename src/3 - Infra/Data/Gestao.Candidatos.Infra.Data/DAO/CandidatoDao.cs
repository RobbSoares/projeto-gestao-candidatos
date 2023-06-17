using Dapper;
using Engenharia.Gestao.De.Candidatos;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Infra.Data.DAO;
using MySqlConnector;
using System.Collections.Generic;

namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class CandidatoDAO : AbstractDAO
    {
        public CandidatoDAO()
        {
        }

        public override string Atualizar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override List<IEntidade> Consultar(IEntidade entidade)
        {
            OpenConnection();

            var candidato = (Candidato)entidade;
            string sql = "SELECT * FROM candidatos WHERE can_id = @Id";

            try
            {
                List<IEntidade> candidatos = new List<IEntidade>();

                using MySqlCommand command = new(sql, _connection);

                command.Parameters.AddWithValue("@Id", candidato.Id);

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Candidato cand = new Candidato();
                    cand.Id = reader.GetInt32("can_id");
                    cand.Nome = reader.GetString("can_nome");
                    cand.DtCadastro = reader.GetDateTime("can_dt_registro");
                    cand.NomeMae = reader.GetString("can_nome_mae");
                    cand.NomePai = reader.GetString("can_nome_pai");

                    candidatos.Add(cand);
                }

                return candidatos;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            _connection.Close();
        }

        public override string Deletar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override void Salvar(IEntidade? entidade)
        {
            OpenConnection();

            var candidato = (Candidato)entidade;
            var endereco = candidato.Endereco;


            EnderecoDAO enderecoDAO = new EnderecoDAO();
            enderecoDAO.Salvar(endereco);
            Console.WriteLine(endereco);
            string sql = "INSERT INTO candidatos(can_nome, can_nome_pai, can_nome_mae, can_dt_registro) VALUES (@nome,@nomePai, @nomeMae,@registro)";
            //string sqlCanEnd = "INSERT INTO candidatos_enderecos (cen_can_id, cen_end_id) VALUES (@nome, @endereco)";

            MySqlTransaction transaction = _connection.BeginTransaction();
            try
            {
                using (MySqlCommand command = new(sql, _connection, transaction))
                {
                    command.Parameters.AddWithValue("@nome", candidato.Nome);
                    command.Parameters.AddWithValue("@nomePai", candidato.NomePai);
                    command.Parameters.AddWithValue("@nomeMae", candidato.NomeMae);
                    command.Parameters.AddWithValue("@registro", candidato.DtCadastro);
                    command.ExecuteNonQuery();
                    candidato.Id = (int)command.LastInsertedId;
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            _connection.Close();
        }
    }
}
