namespace Citel.Conecta.Api.Dtos
{
    public record TributacaoMonitoramentoResponse(
        long Id,
        string NomeCliente,
        string Plataforma,
        string? Erro,
        DateTime DataRegistro,
        string CodigoExterno,
        string? CodigoInterno,
        string NomeWorkflow
    ) : MonitoramentoResponseBase(Id, NomeCliente, Plataforma, Erro, DataRegistro, CodigoExterno, CodigoInterno, NomeWorkflow);
}
