using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.Domain.Entities;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;

namespace Gestao.Candidatos.API.ViewHelper.Interfaces
{
    public interface IViewHelper
    {

        public Entidade GetEntidade(Request<Entidade> request);
        public Response SetView(Result resultado, Request<Entidade> request);
        public Response SetView(Result resultado);
    }

}
