using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class ClienteMonitoramentoService
        : MonitoramentoServiceBase<ClienteMonitoramento, ClienteMonitoramentoRequest, ClienteMonitoramentoResponse>,
          IClienteMonitoramentoService
    {
        public ClienteMonitoramentoService(AppDbContext context) : base(context) { }

        protected override ClienteMonitoramentoResponse ToResponse(ClienteMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
