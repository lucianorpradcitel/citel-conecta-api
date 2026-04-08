using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class CondicaoPagamentoMonitoramentoService
        : MonitoramentoServiceBase<CondicaoPagamentoMonitoramento, CondicaoPagamentoMonitoramentoRequest, CondicaoPagamentoMonitoramentoResponse>,
          ICondicaoPagamentoMonitoramentoService
    {
        public CondicaoPagamentoMonitoramentoService(AppDbContext context) : base(context) { }

        protected override CondicaoPagamentoMonitoramentoResponse ToResponse(CondicaoPagamentoMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
