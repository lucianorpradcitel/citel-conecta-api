using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class EstoqueMonitoramentoService
        : MonitoramentoServiceBase<EstoqueMonitoramento, EstoqueMonitoramentoRequest, EstoqueMonitoramentoResponse>,
          IEstoqueMonitoramentoService
    {
        public EstoqueMonitoramentoService(AppDbContext context) : base(context) { }

        protected override EstoqueMonitoramentoResponse ToResponse(EstoqueMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoEntidade, entity.CodigoInterno,
                entity.NomeWorkflow, entity.TipoEntidade);
    }
}
