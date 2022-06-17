using AvaliacaoEspartaLabs.Application.IApplicationService;
using AvaliacaoEspartaLabs.Model;
using Microsoft.AspNetCore.Mvc;

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

    }
}
