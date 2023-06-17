using Engenharia.Gestao.De.Candidatos.Domain;
using Gestao.Candidatos.API.ViewHelper;
using Gestao.Candidatos.API.ViewHelper.Interfaces;
using Gestao.Candidatos.Application.Commands;
using Gestao.Candidatos.Application.Commands.Interfaces;
using Gestao.Candidatos.Domain.Entities;
using Gestao.Candidatos.Domain.Interfaces;
using Gestao.Candidatos.Domain.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace Gestao.Candidatos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatoController : Controller
    {
        private Dictionary<string, ICommand> commands;
        private Dictionary<string, IViewHelper> viewHelpers;
        private IViewHelper viewHelper;
        private ICommand command;
        private Request request;
        private string operacao;
        private string classe;

        public CandidatoController()
        {
            commands = new Dictionary<string, ICommand>();
            commands.Add("SALVAR", new SalvarCommand());
            commands.Add("CONSULTAR", new ConsultarCommand());
            commands.Add("ALTERAR", new SalvarCommand());
            commands.Add("EXCLUIR", new ExcluirCommand());

            viewHelpers = new Dictionary<string, IViewHelper>();
            viewHelpers.Add("SalvarCandidato", new CandidatoViewHelper());
        }

        [HttpGet("{id}/{operacao}/{classe}")]
        public ActionResult Get([FromRoute] string id, [FromRoute] string operacao, [FromRoute] string classe)
        {
            Entidade ent = new Entidade { Id = int.Parse(id) };
            Request request = new Request { Entidade = ent, Classe = classe, Operacao = operacao };

            Result result = ProcessRequest(request);
            Response response = new Response();
            response.Mensagem = result.Mensagem;
            response.Entidades = new Dictionary<string, List<object>>();

            // Adicione as entidades ao dicionário
            foreach (IEntidade entidade in result.Entidades)
            {
                string nomeClasse = entidade.GetType().Name;

                if (!response.Entidades.ContainsKey(nomeClasse))
                {
                    response.Entidades[nomeClasse] = new List<object>();
                }

                response.Entidades[nomeClasse].Add(entidade);
            }

            return Ok(response.Data);
        }

        protected Result ProcessRequest(Request request)
        {
            classe = request.Classe;

            this.request = request;

            Result resultado = DoProcess();

            return viewHelper.SetView(resultado, request);
        }

        protected Result DoProcess()
        {
            viewHelper = viewHelpers[classe];

            IEntidade entidade = viewHelper.GetEntidade(request);

            if (request == null)
            {
                operacao = "CONSULTAR";
            }
            else
            {
                operacao = request.Operacao;
            }

            if (operacao != null)
            {
                command = commands[operacao];
                Result resultado = command.Execute(entidade);

                return resultado;
            }

            return null;
        }
    }
}
