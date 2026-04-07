using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/titulos")]
    public class TituloMonitoramentoController
        : MonitoramentoControllerBase<TituloMonitoramento, TituloMonitoramentoRequest, TituloMonitoramentoResponse>
    {
        public TituloMonitoramentoController(ITituloMonitoramentoService service) : base(service) { }
    }
}
