namespace Citel.Conecta.Api.Dtos
{
    public record HeartbeatRequest(
        string NomeWorkflow,
        string TipoEntidade,
        int ItensProcessados,
        int CicloEsperadoSegundos
    );
}
