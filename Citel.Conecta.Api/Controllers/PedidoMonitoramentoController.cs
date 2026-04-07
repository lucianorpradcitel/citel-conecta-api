using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/pedidos")]
    public class PedidoMonitoramentoController
        : MonitoramentoControllerBase<PedidoMonitoramento, PedidoMonitoramentoRequest, PedidoMonitoramentoResponse>
    {
        public PedidoMonitoramentoController(IPedidoMonitoramentoService service) : base(service) { }
    }
}
