using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [Route("api/monitoramento/tabelas-preco")]
    public class TabelaPrecoMonitoramentoController
        : MonitoramentoControllerBase<TabelaPrecoMonitoramento, TabelaPrecoMonitoramentoRequest, TabelaPrecoMonitoramentoResponse>
    {
        public TabelaPrecoMonitoramentoController(ITabelaPrecoMonitoramentoService service) : base(service) { }
    }
}
