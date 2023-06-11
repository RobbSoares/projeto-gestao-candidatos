using Engenharia.Gestao.De.Candidatos;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Infra.Data.DAO;
using MySqlConnector;
using System.Collections.Generic;

namespace Engenharia.Gestao.De.Candidatos.Domain
{
    public class CandidatoDao : AbstractDAO
    {
        public CandidatoDao(MySqlConnection connection) 
            : base(connection)
        {
        }

        public override string Atualizar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IEntidade> Consultar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override string Deletar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public override string Salvar(IEntidade entidade)
        {
            throw new NotImplementedException();
        }
    }
}
