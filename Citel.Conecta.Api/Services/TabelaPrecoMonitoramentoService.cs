using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class TabelaPrecoMonitoramentoService
        : MonitoramentoServiceBase<TabelaPrecoMonitoramento, TabelaPrecoMonitoramentoRequest, TabelaPrecoMonitoramentoResponse>,
          ITabelaPrecoMonitoramentoService
    {
        public TabelaPrecoMonitoramentoService(AppDbContext context) : base(context) { }

        protected override TabelaPrecoMonitoramentoResponse ToResponse(TabelaPrecoMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
