namespace Citel.Conecta.Api.Dtos
{
    public record HeartbeatResponse(
        long Id,
        string NomeWorkflow,
        string TipoEntidade,
        DateTime UltimaExecucao,
        DateTime? UltimoSucesso,
        int ItensProcessados,
        int CicloEsperadoSegundos,
        string Status // "OK", "ATRASADO", "FALHA"
    );
}
