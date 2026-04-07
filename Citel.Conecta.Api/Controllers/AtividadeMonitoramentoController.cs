using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/atividades")]
    public class AtividadeMonitoramentoController
        : MonitoramentoControllerBase<AtividadeMonitoramento, AtividadeMonitoramentoRequest, AtividadeMonitoramentoResponse>
    {
        public AtividadeMonitoramentoController(IAtividadeMonitoramentoService service) : base(service) { }
    }
}
