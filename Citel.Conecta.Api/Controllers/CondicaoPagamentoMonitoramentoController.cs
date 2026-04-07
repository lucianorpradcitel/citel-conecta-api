using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/condicoes-pagamento")]
    public class CondicaoPagamentoMonitoramentoController
        : MonitoramentoControllerBase<CondicaoPagamentoMonitoramento, CondicaoPagamentoMonitoramentoRequest, CondicaoPagamentoMonitoramentoResponse>
    {
        public CondicaoPagamentoMonitoramentoController(ICondicaoPagamentoMonitoramentoService service) : base(service) { }
    }
}
