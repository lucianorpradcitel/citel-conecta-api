namespace Citel.Conecta.Api.Dtos
{
    public record HeartbeatRequest(
        string NomeWorkflow,
        int CicloEsperadoSegundos
    );
}
