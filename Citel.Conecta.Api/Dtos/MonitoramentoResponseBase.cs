namespace Citel.Conecta.Api.Dtos
{
    public record MonitoramentoResponseBase(
        long Id,
        string NomeCliente,
        string Plataforma,
        string? Erro,
        DateTime DataRegistro,
        string CodigoEntidade,
        string? CodigoInterno,
        string NomeWorkflow,
        string TipoEntidade
    );
}
