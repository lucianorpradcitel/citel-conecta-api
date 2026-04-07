using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/produtos")]
    public class ProdutoMonitoramentoController
        : MonitoramentoControllerBase<ProdutoMonitoramento, ProdutoMonitoramentoRequest, ProdutoMonitoramentoResponse>
    {
        public ProdutoMonitoramentoController(IProdutoMonitoramentoService service) : base(service) { }
    }
}
