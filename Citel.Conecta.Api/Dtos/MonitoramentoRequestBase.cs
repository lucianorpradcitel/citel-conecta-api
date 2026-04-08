namespace Citel.Conecta.Api.Dtos
{
    public record MonitoramentoRequestBase(
        string NomeCliente,
        string Plataforma,
        string? Erro,
        string CodigoExterno,
        string? CodigoInterno,
        string NomeWorkflow
    );
}
