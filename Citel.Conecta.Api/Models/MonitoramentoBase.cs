namespace Citel.Conecta.Api.Models
{
    public abstract class MonitoramentoBase
    {
        public long Id { get; set; }
        public string NomeCliente { get; set; } = null!;
        public string Plataforma { get; set; } = null!;
        public DateTime DataRegistro { get; set; }
        public string? Erro { get; set; }
        public string CodigoExterno { get; set; } = null!;
        public string? CodigoInterno { get; set; }
        public string NomeWorkflow { get; set; } = null!;
    }
}
