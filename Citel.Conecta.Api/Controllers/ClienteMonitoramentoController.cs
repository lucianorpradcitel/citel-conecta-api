using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/clientes")]
    public class ClienteMonitoramentoController
        : MonitoramentoControllerBase<ClienteMonitoramento, ClienteMonitoramentoRequest, ClienteMonitoramentoResponse>
    {
        public ClienteMonitoramentoController(IClienteMonitoramentoService service) : base(service) { }
    }
}
