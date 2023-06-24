using Engenharia.Candidatos.WebUI.Data;
using Engenharia.Candidatos.Domain;
using Engenharia.Candidatos.API.ViewHelper;
using Engenharia.Candidatos.API.ViewHelper.Interfaces;
using Engenharia.Candidatos.Application.Commands;
using Engenharia.Candidatos.Application.Commands.Interfaces;
using Engenharia.Candidatos.Domain.Entities;
using Engenharia.Candidatos.Domain.Interfaces;
using Engenharia.Candidatos.Domain.Result;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace Engenharia.Candidatos.WebUI.Controllers;

[ApiController]
[Route("[controller]")]
public class CandidatoController : ControllerBase
{
    private Dictionary<string, ICommand> commands;
    private Dictionary<string, IViewHelper> viewHelpers;
    private IViewHelper viewHelper;
    private ICommand command;
    private Request<Entidade> request;
    private string _operacaoViewHelper;

    public CandidatoController()
    {
        commands = new Dictionary<string, ICommand>();
        commands.Add("SALVAR", new SalvarCommand());
        commands.Add("CONSULTAR", new ConsultarCommand());
        commands.Add("ALTERAR", new AlterarCommand());
        commands.Add("EXCLUIR", new ExcluirCommand());

        var candidatoViewHelper = new CandidatoViewHelper();

        viewHelpers = new Dictionary<string, IViewHelper>
        {
            { "SalvarCandidato", candidatoViewHelper },
            { "ConsultarCandidato", candidatoViewHelper },
            { "AlterarCandidato", candidatoViewHelper },
            { "ExcluirCandidato", candidatoViewHelper }
        };
    }

    [HttpPost("consultarCandidato")]
    public ActionResult Get(Request<Candidato> request)
    {
        _operacaoViewHelper = "ConsultarCandidato";

        var entidadeRequest = new Request<Entidade>
        {
            Entidade = request.Entidade,
            Operacao = request.Operacao.ToUpper()
        };

        var result = ProcessRequest(entidadeRequest);
        return Ok(new { result.StatusCode, result.Mensagem, result.Data, });
    }

    [HttpPost("salvarCandidato")]
    public ActionResult Post(Request<Candidato> request)
    {
        _operacaoViewHelper = "SalvarCandidato";

        var entidadeRequest = new Request<Entidade>
        {
            Entidade = request.Entidade,
            Operacao = request.Operacao.ToUpper()
        };

        var result = ProcessRequest(entidadeRequest);
        return Ok(new { result.StatusCode, result.Mensagem, result.Data, });
    }

    [HttpDelete("excluirCandidato")]
    public ActionResult Delete(Request<Candidato> request)
    {
        _operacaoViewHelper = "ExcluirCandidato";

        var entidadeRequest = new Request<Entidade>
        {
            Entidade = request.Entidade,
            Operacao = request.Operacao.ToUpper()
        };

        var result = ProcessRequest(entidadeRequest);
        return Ok(new { result.StatusCode, result.Mensagem, result.Data, });
    }

    [HttpPut("alterarCandidato")]
    public ActionResult Put(Request<Candidato> request)
    {
        _operacaoViewHelper = "AlterarCandidato";

        var entidadeRequest = new Request<Entidade>
        {
            Entidade = request.Entidade,
            Operacao = request.Operacao.ToUpper()
        };

        var result = ProcessRequest(entidadeRequest);
        return Ok(new { result.StatusCode, result.Mensagem, result.Data, });
    }

    protected Response ProcessRequest(Request<Entidade> request)
    {
        this.request = request;
        Result resultado = DoProcess();

        return viewHelper.SetView(resultado, request);
    }

    protected Result DoProcess()
    {
        viewHelper = viewHelpers[_operacaoViewHelper];

        Entidade entidade = viewHelper.GetEntidade(request);

        if (request.Operacao == null)
        {
            request.Operacao = "CONSULTAR";
        }

        if (request.Operacao != null)
        {
            command = commands[request.Operacao.ToUpper()];
            Result resultado = command.Execute(entidade);

            return resultado;
        }

        return null;
    }
}
