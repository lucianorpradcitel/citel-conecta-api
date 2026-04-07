namespace Citel.Conecta.Api.Models
{
    public class Heartbeat
    {
        public long Id { get; set; }
        public string NomeWorkflow { get; set; }
        public string TipoEntidade { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public DateTime? UltimoSucesso { get; set; }
        public int ItensProcessados { get; set; }
        public int CicloEsperadoSegundos { get; set; }
    }
}
