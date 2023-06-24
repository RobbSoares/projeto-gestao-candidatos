using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.Domain.Entities;
using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;

namespace Engenharia.Candidatos.API.ViewHelper.Interfaces
{
    public interface IViewHelper
    {

        public Entidade GetEntidade(Request<Entidade> request);
        public Response SetView(Result resultado, Request<Entidade> request);
        public Response SetView(Result resultado);
    }

}
