using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/monitoramento/resumo")]
    public class ResumoController : ControllerBase
    {
        private readonly IResumoService _resumoService;

        public ResumoController(IResumoService resumoService)
        {
            _resumoService = resumoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterResumo()
        {
            return Ok(await _resumoService.ObterResumoAsync());
        }
    }
}
