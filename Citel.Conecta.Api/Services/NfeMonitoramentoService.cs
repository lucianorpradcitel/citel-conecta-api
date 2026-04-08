using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class NfeMonitoramentoService
        : MonitoramentoServiceBase<NfeMonitoramento, NfeMonitoramentoRequest, NfeMonitoramentoResponse>,
          INfeMonitoramentoService
    {
        public NfeMonitoramentoService(AppDbContext context) : base(context) { }

        protected override NfeMonitoramentoResponse ToResponse(NfeMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
