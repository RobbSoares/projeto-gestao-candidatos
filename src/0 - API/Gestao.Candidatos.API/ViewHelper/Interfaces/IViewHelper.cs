using Gestao.Candidatos.Domain.Entities;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;

namespace Gestao.Candidatos.API.ViewHelper.Interfaces
{
    public interface IViewHelper
    {

        public IEntidade GetEntidade(Request request);
        public Result SetView(Result resultado, Request request);
        public void SetView(Result resultado);
    }

}
