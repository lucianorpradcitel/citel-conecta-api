namespace Citel.Conecta.Api.Dtos
{
    public record HeartbeatResponse(
        long Id,
        string NomeWorkflow,
        DateTime UltimaExecucao,
        DateTime? UltimoSucesso,
        int CicloEsperadoSegundos,
        string Status // "OK", "ATRASADO", "FALHA"
    );
}
