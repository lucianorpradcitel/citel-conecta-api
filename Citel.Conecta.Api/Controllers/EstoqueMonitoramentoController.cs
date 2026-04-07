using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/estoques")]
    public class EstoqueMonitoramentoController
        : MonitoramentoControllerBase<EstoqueMonitoramento, EstoqueMonitoramentoRequest, EstoqueMonitoramentoResponse>
    {
        public EstoqueMonitoramentoController(IEstoqueMonitoramentoService service) : base(service) { }
    }
}
