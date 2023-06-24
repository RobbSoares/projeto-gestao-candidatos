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
    public class CursoDAO : AbstractDAO
    {
        public CursoDAO()
        {
        }

        public override string Atualizar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override List<IEntidade> Consultar(IEntidade entidade)
        {
            OpenConnection();

            string sql = "SELECT * FROM cursos";

            try
            {
                List<IEntidade> cursos = new List<IEntidade>();

                using MySqlCommand command = new(sql, _connection);

                using MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Curso curso = new Curso();

                    curso.Id = reader.GetInt32("cur_id");
                    curso.Nome = reader.GetString("cur_nome");
                    curso.Descricao = reader.GetString("cur_descricao");

                    cursos.Add(curso);
                }

                return cursos;
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

        public override void Salvar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}
