using Engenharia.Gestao.De.Candidatos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Engenharia.Gestao.De.Candidatos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatosController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            CandidatoDao candidatoDao = new CandidatoDao();
            var candidatos = candidatoDao.Consultar();
            return Ok(candidatos.ToList());
        }

        [HttpPost]
        public IActionResult Post(Candidato candidato)
        {
            return Ok(candidato);
        }

        [HttpPut]
        public IActionResult Put(Candidato candidato)
        {
            CandidatoDao candidatoDao = new CandidatoDao();
            var candidatos = candidatoDao.Consultar();
            return Ok(candidatos.ToList());
        }

        [HttpDelete]
        public IActionResult Delete(Candidato candidato)
        {
            var candidato1 = new Candidato();

            candidato1.Prioridade = 1;
            candidato1.Filiacao = candidato.Filiacao;
            candidato1.CursoInteresse = candidato.CursoInteresse;
            candidato1.CursoMatriculado = "Engenharia de Software";
            candidato1.Nome = "Joredson";

            return Ok(candidato1);
        }
    }
}
