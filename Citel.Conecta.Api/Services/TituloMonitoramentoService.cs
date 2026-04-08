using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class TituloMonitoramentoService
        : MonitoramentoServiceBase<TituloMonitoramento, TituloMonitoramentoRequest, TituloMonitoramentoResponse>,
          ITituloMonitoramentoService
    {
        public TituloMonitoramentoService(AppDbContext context) : base(context) { }

        protected override TituloMonitoramentoResponse ToResponse(TituloMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
