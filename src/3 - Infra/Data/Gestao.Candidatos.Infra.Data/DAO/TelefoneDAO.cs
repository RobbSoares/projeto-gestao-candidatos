﻿using Gestao.Candidatos.Domain.Interfaces;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Candidatos.Infra.Data.DAO
{
    public class TelefoneDAO : AbstractDAO
    {
        public TelefoneDAO(MySqlConnection connection) : base(connection)
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