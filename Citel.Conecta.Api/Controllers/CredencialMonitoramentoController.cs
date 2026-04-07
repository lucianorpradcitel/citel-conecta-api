using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/credenciais")]
    public class CredencialMonitoramentoController
        : MonitoramentoControllerBase<CredencialMonitoramento, CredencialMonitoramentoRequest, CredencialMonitoramentoResponse>
    {
        public CredencialMonitoramentoController(ICredencialMonitoramentoService service) : base(service) { }
    }
}
