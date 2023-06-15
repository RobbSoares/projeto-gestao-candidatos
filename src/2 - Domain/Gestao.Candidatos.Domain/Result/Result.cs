using Engenharia.Gestao.De.Candidatos.Domain;

namespace Gestao.Candidatos.Domain.Result
{
    public class Result : EntidadeAplicacao
    {
        private string msg;
        private List<Entidade> entidades;

        public Result(List<Entidade> entidades) => this.entidades = entidades;

        public string GetMessage() => msg;
        public void SetMessage(string msg) => this.msg = msg;
        public List<Entidade> GetEntidades() => entidades;
        public void SetEntidades(List<Entidade> entidades) => this.entidades = entidades;
    }
}
