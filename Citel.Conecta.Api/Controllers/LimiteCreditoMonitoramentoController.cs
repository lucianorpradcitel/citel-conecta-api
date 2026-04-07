using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/limites-credito")]
    public class LimiteCreditoMonitoramentoController
        : MonitoramentoControllerBase<LimiteCreditoMonitoramento, LimiteCreditoMonitoramentoRequest, LimiteCreditoMonitoramentoResponse>
    {
        public LimiteCreditoMonitoramentoController(ILimiteCreditoMonitoramentoService service) : base(service) { }
    }
}
