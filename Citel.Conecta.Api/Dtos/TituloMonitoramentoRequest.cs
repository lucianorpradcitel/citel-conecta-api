namespace Citel.Conecta.Api.Dtos
{
    public record TituloMonitoramentoRequest(
        string NomeCliente,
        string Plataforma,
        string? Erro,
        string CodigoEntidade,
        string? CodigoInterno,
        string NomeWorkflow,
        string TipoEntidade
    ) : MonitoramentoRequestBase(NomeCliente, Plataforma, Erro, CodigoEntidade, CodigoInterno, NomeWorkflow, TipoEntidade);
}
