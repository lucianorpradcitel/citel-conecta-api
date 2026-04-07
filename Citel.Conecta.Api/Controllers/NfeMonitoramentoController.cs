using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/nfe")]
    public class NfeMonitoramentoController
        : MonitoramentoControllerBase<NfeMonitoramento, NfeMonitoramentoRequest, NfeMonitoramentoResponse>
    {
        public NfeMonitoramentoController(INfeMonitoramentoService service) : base(service) { }
    }
}
