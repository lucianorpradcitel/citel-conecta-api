using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class PrecoMonitoramentoService
        : MonitoramentoServiceBase<PrecoMonitoramento, PrecoMonitoramentoRequest, PrecoMonitoramentoResponse>,
          IPrecoMonitoramentoService
    {
        public PrecoMonitoramentoService(AppDbContext context) : base(context) { }

        protected override PrecoMonitoramentoResponse ToResponse(PrecoMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
