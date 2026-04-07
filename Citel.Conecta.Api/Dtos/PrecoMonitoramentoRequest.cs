namespace Citel.Conecta.Api.Dtos
{
    public record PrecoMonitoramentoRequest(
        string NomeCliente,
        string Plataforma,
        string? Erro,
        string CodigoEntidade,
        string? CodigoInterno,
        string NomeWorkflow,
        string TipoEntidade
    ) : MonitoramentoRequestBase(NomeCliente, Plataforma, Erro, CodigoEntidade, CodigoInterno, NomeWorkflow, TipoEntidade);
}
