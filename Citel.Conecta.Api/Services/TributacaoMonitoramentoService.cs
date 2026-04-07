using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class TributacaoMonitoramentoService
        : MonitoramentoServiceBase<TributacaoMonitoramento, TributacaoMonitoramentoRequest, TributacaoMonitoramentoResponse>,
          ITributacaoMonitoramentoService
    {
        public TributacaoMonitoramentoService(AppDbContext context) : base(context) { }

        protected override TributacaoMonitoramentoResponse ToResponse(TributacaoMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoEntidade, entity.CodigoInterno,
                entity.NomeWorkflow, entity.TipoEntidade);
    }
}
