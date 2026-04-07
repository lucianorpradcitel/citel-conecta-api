using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class PedidoMonitoramentoService
        : MonitoramentoServiceBase<PedidoMonitoramento, PedidoMonitoramentoRequest, PedidoMonitoramentoResponse>,
          IPedidoMonitoramentoService
    {
        public PedidoMonitoramentoService(AppDbContext context) : base(context) { }

        protected override PedidoMonitoramentoResponse ToResponse(PedidoMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoEntidade, entity.CodigoInterno,
                entity.NomeWorkflow, entity.TipoEntidade);
    }
}
