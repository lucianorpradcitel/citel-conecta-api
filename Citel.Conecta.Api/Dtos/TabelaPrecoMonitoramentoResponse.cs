namespace Citel.Conecta.Api.Dtos
{
    public record TabelaPrecoMonitoramentoResponse(
        long Id,
        string NomeCliente,
        string Plataforma,
        string? Erro,
        DateTime DataRegistro,
        string CodigoEntidade,
        string? CodigoInterno,
        string NomeWorkflow,
        string TipoEntidade
    ) : MonitoramentoResponseBase(Id, NomeCliente, Plataforma, Erro, DataRegistro, CodigoEntidade, CodigoInterno, NomeWorkflow, TipoEntidade);
}
