using Dapper;
using Engenharia.Candidatos;
using Engenharia.Candidatos.Domain.Entities;
using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Infra.Data.DAO;
using MySqlConnector;
using System.Collections.Generic;

namespace Engenharia.Candidatos.Domain
{
    public class CandidatoDAO : AbstractDAO
    {
        public CandidatoDAO()
        {
        }

        public override string Atualizar(IEntidade entidade)
        {
            OpenConnection();

            var candidato = (Candidato)entidade;

            string sql = "UPDATE candidatos SET can_nome = @nome, can_nome_pai = @nomePai, can_nome_mae = @nomeMae, can_dt_registro = @registro WHERE can_id = @Id";

            MySqlTransaction transaction = _connection.BeginTransaction();
            try
            {
                using (MySqlCommand command = new(sql, _connection, transaction))
                {
                    command.Parameters.AddWithValue("@Id", candidato.Id);
                    command.Parameters.AddWithValue("@nome", candidato.Nome);
                    command.Parameters.AddWithValue("@nomePai", candidato.NomePai);
                    command.Parameters.AddWithValue("@nomeMae", candidato.NomeMae);
                    command.Parameters.AddWithValue("@registro", candidato.DtCadastro);

                    int rowsAffected = command.ExecuteNonQuery();
                    transaction.Commit();

                    return "Usuario deletado";
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }

            _connection.Close();
        }

        public override List<IEntidade> Consultar(IEntidade entidade)
        {
            OpenConnection();

            var candidato = (Candidato)entidade;
            string sql = "SELECT * FROM candidatos WHERE can_email = @Email AND can_senha = @Senha";

            try
            {
                List<IEntidade> candidatos = new List<IEntidade>();

                using MySqlCommand command = new(sql, _connection);

                command.Parameters.AddWithValue("@Email", candidato.Email);
                command.Parameters.AddWithValue("@Senha", candidato.Senha);

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
            OpenConnection();

            var candidato = (Candidato) entidade;
            string sql = "DELETE FROM candidatos WHERE can_id = @Id";
            MySqlTransaction transaction = _connection.BeginTransaction();
            try
            {
                using MySqlCommand command = new(sql, _connection, transaction);
                command.Parameters.AddWithValue("@Id", candidato.Id);
                int rowsAffected = command.ExecuteNonQuery();
                transaction.Commit();
                return "Usuario deletado";
            }
            catch (MySqlException ex)
            {
                transaction.Rollback();
                throw ex;
            }

            _connection.Close();
        }

        public override void Salvar(IEntidade? entidade)
        {
            OpenConnection();

            var candidato = (Candidato)entidade;
            var endereco = candidato.Endereco;

            CandidatoEnderecoDAO candEnd = new CandidatoEnderecoDAO();
            CandidatoTelefoneDAO candidatoTelefone = new CandidatoTelefoneDAO();

            EnderecoDAO enderecoDAO = new EnderecoDAO();
            enderecoDAO.Salvar(endereco);

            TelefoneDAO telefoneDAO = new TelefoneDAO();
            telefoneDAO.Salvar(candidato);

            Console.WriteLine(endereco);
            string sql = "INSERT INTO candidatos(can_nome, can_nome_pai, can_nome_mae, can_dt_registro, can_email, can_senha) VALUES (@nome,@nomePai, @nomeMae,@registro, @email, @senha)";
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
                    command.Parameters.AddWithValue("@email", candidato.Email);
                    command.Parameters.AddWithValue("@senha", candidato.Senha);
                    command.ExecuteNonQuery();
                    candidato.Id = (int)command.LastInsertedId;
                    transaction.Commit();
                }

                
                candEnd.Salvar(candidato);
                candidatoTelefone.Salvar(candidato);

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
