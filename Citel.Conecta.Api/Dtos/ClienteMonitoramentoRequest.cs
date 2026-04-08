namespace Citel.Conecta.Api.Dtos
{
    public record ClienteMonitoramentoRequest(
        string NomeCliente,
        string Plataforma,
        string? Erro,
        string CodigoExterno,
        string? CodigoInterno,
        string NomeWorkflow
    ) : MonitoramentoRequestBase(NomeCliente, Plataforma, Erro, CodigoExterno, CodigoInterno, NomeWorkflow);
}
