namespace Citel.Conecta.Api.Models
{
    public abstract class MonitoramentoBase
    {
        public long Id { get; set; }
        public string NomeCliente { get; set; }
        public string Plataforma { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? Erro { get; set; }
        public string CodigoEntidade { get; set; }
        public string? CodigoInterno { get; set; }
        public string NomeWorkflow { get; set; }
        public string TipoEntidade { get; set; }
    }
}
