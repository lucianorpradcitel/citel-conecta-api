using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [ApiController]
    [Authorize]
    public abstract class MonitoramentoControllerBase<TEntity, TRequest, TResponse> : ControllerBase
        where TEntity : MonitoramentoBase
        where TRequest : MonitoramentoRequestBase
        where TResponse : MonitoramentoResponseBase
    {
        private readonly IMonitoramentoServiceBase<TRequest, TResponse> _service;

        protected MonitoramentoControllerBase(IMonitoramentoServiceBase<TRequest, TResponse> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos(
            [FromQuery] string? plataforma,
            [FromQuery] string? nomeCliente,
            [FromQuery] string? nomeWorkflow,
            [FromQuery] string? codigoEntidade,
            [FromQuery] DateTime? dataInicio,
            [FromQuery] DateTime? dataFim,
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanhoPagina = 50)
        {
            var resultado = await _service.ObterTodosAsync(
                plataforma, nomeCliente, nomeWorkflow, codigoEntidade,
                dataInicio, dataFim, pagina, tamanhoPagina);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] TRequest request)
        {
            var response = await _service.RegistrarAsync(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(long id)
        {
            await _service.RemoverAsync(id);
            return NoContent();
        }
    }
}
