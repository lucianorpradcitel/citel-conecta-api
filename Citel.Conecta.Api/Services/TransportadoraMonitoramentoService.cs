using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class TransportadoraMonitoramentoService
        : MonitoramentoServiceBase<TransportadoraMonitoramento, TransportadoraMonitoramentoRequest, TransportadoraMonitoramentoResponse>,
          ITransportadoraMonitoramentoService
    {
        public TransportadoraMonitoramentoService(AppDbContext context) : base(context) { }

        protected override TransportadoraMonitoramentoResponse ToResponse(TransportadoraMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
