using Engenharia.Gestao.De.Candidatos;
using Gestao.Candidatos.Domain.Interfaces;
using System.Collections.Generic;

namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class CandidatoDao : IDao
    {
        public string Atualizar(Candidato candidato)
        {
            throw new NotImplementedException();
        }

        public string Criar(Candidato candidato)
        {
            
            throw new NotImplementedException();
        }

        public string Deletar(Candidato candidato)
        {
            throw new NotImplementedException();
        }

        public string Salvar(Candidato candidato)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Candidato> Consultar(Candidato candidato)
        {
            string connectionString = "Data Source=192.168.1.110:1521/oracle;User Id=app;Password=123;Validate Connection=true;";
            var dataBase = new DatabaseConnection(connectionString);

            var candidatos = dataBase.Query<Candidato>("select * from candidatos");

            return candidatos;
        }
    }
}
