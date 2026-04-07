using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class AtividadeMonitoramentoService
        : MonitoramentoServiceBase<AtividadeMonitoramento, AtividadeMonitoramentoRequest, AtividadeMonitoramentoResponse>,
          IAtividadeMonitoramentoService
    {
        public AtividadeMonitoramentoService(AppDbContext context) : base(context) { }

        protected override AtividadeMonitoramentoResponse ToResponse(AtividadeMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoEntidade, entity.CodigoInterno,
                entity.NomeWorkflow, entity.TipoEntidade);
    }
}
