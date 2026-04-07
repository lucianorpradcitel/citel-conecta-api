namespace Citel.Conecta.Api.Dtos
{
    public record MonitoramentoRequestBase(
        string NomeCliente,
        string Plataforma,
        string? Erro,
        string CodigoEntidade,
        string? CodigoInterno,
        string NomeWorkflow,
        string TipoEntidade
    );
}
