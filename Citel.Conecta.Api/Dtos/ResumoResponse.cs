namespace Citel.Conecta.Api.Dtos
{
    public record EntidadeResumo(
        string Entidade,
        int ErrosAtivos,
        DateTime? UltimoSucesso,
        string Status // "verde", "amarelo", "vermelho"
    );

    public record ResumoResponse(
        int TotalErros,
        IEnumerable<EntidadeResumo> PorEntidade,
        Dictionary<string, int> PorPlataforma,
        bool CredenciaisOk
    );
}
