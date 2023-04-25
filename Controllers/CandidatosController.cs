using Engenharia.Gestao.De.Candidatos.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Engenharia.Gestao.De.Candidatos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatosController : Controller
    {
        [HttpGet]
        public IActionResult Get(Candidato candidato)
        {
            var candidatoDao = new CandidatoDao();
            var candidatos = candidatoDao.Consultar(candidato);
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
            return Ok(candidato);
        }

        [HttpDelete]
        public IActionResult Delete(Candidato candidato)
        {
            return Ok(candidato);
        }
    }
}
