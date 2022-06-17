using AvaliacaoEspartaLabs.API.JWT;
using AvaliacaoEspartaLabs.API.Model;
using AvaliacaoEspartaLabs.Application.IApplicationService;
using AvaliacaoEspartaLabs.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AvaliacaoEspartaLabs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OficinaController : ControllerBase
    {
        private readonly IOficinaApplication _applicationService;
        public OficinaController(IOficinaApplication applicationService)
        {
            _applicationService = applicationService;
        }


        [HttpPost]
        public IActionResult CriarOficina(AddOficinaModel oficina) {

            try
            {
                _applicationService.CriarOficina(new Application.DTO.OficinaDTO {
                    CNPJ = oficina.CNPJ,
                    Nome = oficina.Nome,
                    Senha = oficina.Senha
                });
                return StatusCode(201);
            }
            catch (System.Exception)
            {

                throw;
            }
         
        
        }


        [HttpGet]
        public async Task<IActionResult> Autenticar(string cnpj, string senha) {
            try
            {
               var result = await _applicationService.AutenticarOficina(cnpj, senha);
                return Ok(new AutenticarModelResponse { 
                    Token = TokenService.GenerateTokenJwt(result),
                    CNPJ = result.CNPJ,
                    IdOficina = result.IdOficina,
                    Nome = result.Nome
                });
            }
            catch (System.Exception e)
            {

                return StatusCode(400, e.Message);
            }
        
        }

        [Authorize]
        [HttpGet("Autorizado")]
        public async Task<IActionResult> Autorizado()
        {
            try
            {
                return Ok("Autenticado");
            }
            catch (System.Exception e)
            {

                return StatusCode(400, e.Message);
            }

        }

    }
}
