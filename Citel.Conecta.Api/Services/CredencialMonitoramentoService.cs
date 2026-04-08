using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Services
{
    public class CredencialMonitoramentoService
        : MonitoramentoServiceBase<CredencialMonitoramento, CredencialMonitoramentoRequest, CredencialMonitoramentoResponse>,
          ICredencialMonitoramentoService
    {
        public CredencialMonitoramentoService(AppDbContext context) : base(context) { }

        protected override CredencialMonitoramentoResponse ToResponse(CredencialMonitoramento entity) =>
            new(entity.Id, entity.NomeCliente, entity.Plataforma, entity.Erro,
                entity.DataRegistro, entity.CodigoExterno, entity.CodigoInterno,
                entity.NomeWorkflow);
    }
}
