using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.API.ViewHelper.Interfaces;
using Gestao.Candidatos.Domain.Entities;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Gestao.Candidatos.API.ViewHelper
{
    public class CandidatoViewHelper : IViewHelper
    {
        public IEntidade GetEntidade(Request request)
        {
            String operacao = request.Operacao;
            Candidato candidato = new Candidato();
            candidato.Id = request.Entidade.Id;

            return candidato;
        }

        public Result SetView(Result resultado, Request request)
        {
            try
            {
                String operacao = request.Operacao;

                if (resultado.Mensagem == null)
                {
                    if (operacao.Equals("SALVAR"))
                    {
                        resultado.Mensagem = "Produto cadastrado com sucesso!";
                    }
                }

                if (resultado.Mensagem == null && operacao.Equals("CONSULTAR"))
                {
                    resultado.Mensagem = "Sucesso!";
                }

                if (resultado.Mensagem == null && operacao.Equals("ALTERAR"))
                {
                    return resultado;
                }

                if (resultado.Mensagem == null && operacao.Equals("EXCLUIR"))
                {
                    resultado.Mensagem = "Produto excluído com sucesso!";
                }

            }
            catch (IOException e)
            {

                Console.WriteLine(e.Message);
            }

            return resultado;
        }

        public void SetView(Result resultado)
        {
            throw new NotImplementedException();
        }
    }
}
