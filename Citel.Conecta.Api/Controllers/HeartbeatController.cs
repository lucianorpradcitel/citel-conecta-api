using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/monitoramento/heartbeat")]
    public class HeartbeatController : ControllerBase
    {
        private readonly IHeartbeatService _heartbeatService;

        public HeartbeatController(IHeartbeatService heartbeatService)
        {
            _heartbeatService = heartbeatService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _heartbeatService.ObterTodosAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] HeartbeatRequest request)
        {
            var response = await _heartbeatService.RegistrarAsync(request);
            return Ok(response);
        }
    }
}
