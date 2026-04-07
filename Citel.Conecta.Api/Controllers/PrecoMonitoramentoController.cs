using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/precos")]
    public class PrecoMonitoramentoController
        : MonitoramentoControllerBase<PrecoMonitoramento, PrecoMonitoramentoRequest, PrecoMonitoramentoResponse>
    {
        public PrecoMonitoramentoController(IPrecoMonitoramentoService service) : base(service) { }
    }
}
