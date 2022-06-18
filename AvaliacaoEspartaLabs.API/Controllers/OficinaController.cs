using AvaliacaoEspartaLabs.API.JWT;
using AvaliacaoEspartaLabs.API.Model;
using AvaliacaoEspartaLabs.Application.IApplicationService;
using AvaliacaoEspartaLabs.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
                    Senha = oficina.Senha,
                    CargaTrabalhoOficina = oficina.CargaTrabalhoOficina
                });
                return StatusCode(201);
            }
            catch (System.Exception e)
            {

               return StatusCode(400,e.Message);
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
                    Nome = result.Nome,
                });
            }
            catch (System.Exception e)
            {

                return StatusCode(400, e.Message);
            }
        }

        [HttpPost("AdicionarAgendamentoOficina")]
        public async Task<IActionResult> AdicionarAgendamento([FromBody] AddAgendamento agendamento) {
            try
            {
                await _applicationService.AddCargaTrabalhoAgendaOficina(new Application.DTO.AddAgendamentoDTO
                {
                    Servico = agendamento.Servico,
                    DataAgendamento = agendamento.DataAgendamento,
                    IdOficina =  1/*BuscarIdOficinaAutenticada().GetValueOrDefault()*/
                });
                return StatusCode(201);
            }
            catch (System.Exception e)
            {

                return StatusCode(400,e.Message);
            }
        }

        private string BuscarCnpjOficinaAutenticada()
        {
            if (HttpContext.User.HasClaim(x => x.Type == "CNPJ"))
                return HttpContext.User.Claims.FirstOrDefault(c => c.Type == "CNPJ").Value;
            else return string.Empty;
        }

        private int? BuscarIdOficinaAutenticada()
        {
            if (HttpContext.User.HasClaim(x => x.Type == "IdOficina"))
                return int.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == "IdOficina").Value);
            else return null;
        }
    }
}
