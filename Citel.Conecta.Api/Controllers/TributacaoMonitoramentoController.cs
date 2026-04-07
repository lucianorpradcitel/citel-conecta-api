using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/tributacoes")]
    public class TributacaoMonitoramentoController
        : MonitoramentoControllerBase<TributacaoMonitoramento, TributacaoMonitoramentoRequest, TributacaoMonitoramentoResponse>
    {
        public TributacaoMonitoramentoController(ITributacaoMonitoramentoService service) : base(service) { }
    }
}
