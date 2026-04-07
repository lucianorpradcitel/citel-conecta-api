using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/transportadoras")]
    public class TransportadoraMonitoramentoController
        : MonitoramentoControllerBase<TransportadoraMonitoramento, TransportadoraMonitoramentoRequest, TransportadoraMonitoramentoResponse>
    {
        public TransportadoraMonitoramentoController(ITransportadoraMonitoramentoService service) : base(service) { }
    }
}
