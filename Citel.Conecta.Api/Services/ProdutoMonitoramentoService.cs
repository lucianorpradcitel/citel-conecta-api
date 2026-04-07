using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class ProdutoMonitoramentoService
        : MonitoramentoServiceBase<ProdutoMonitoramento, ProdutoMonitoramentoRequest, ProdutoMonitoramentoResponse>,
          IProdutoMonitoramentoService
    {
        public ProdutoMonitoramentoService(AppDbContext context) : base(context) { }

        protected override ProdutoMonitoramentoResponse ToResponse(ProdutoMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoEntidade, entity.CodigoInterno,
                entity.NomeWorkflow, entity.TipoEntidade);
    }
}
