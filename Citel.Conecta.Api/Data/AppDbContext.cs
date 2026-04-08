using Microsoft.EntityFrameworkCore;
using Citel.Conecta.Api.Models;

namespace Citel.Conecta.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Entidades originais
    public DbSet<ClienteMonitoramento> ClientesMonitoramento { get; set; }
    public DbSet<TituloMonitoramento> TitulosMonitoramento { get; set; }
    public DbSet<TributacaoMonitoramento> TributacoesMonitoramento { get; set; }

    // Novas entidades
    public DbSet<CredencialMonitoramento> CredenciaisMonitoramento { get; set; }
    public DbSet<PedidoMonitoramento> PedidosMonitoramento { get; set; }
    public DbSet<ProdutoMonitoramento> ProdutosMonitoramento { get; set; }
    public DbSet<EstoqueMonitoramento> EstoquesMonitoramento { get; set; }
    public DbSet<PrecoMonitoramento> PrecosMonitoramento { get; set; }
    public DbSet<NfeMonitoramento> NfesMonitoramento { get; set; }
    public DbSet<LimiteCreditoMonitoramento> LimitesCreditorMonitoramento { get; set; }
    public DbSet<TransportadoraMonitoramento> TransportadorasMonitoramento { get; set; }
    public DbSet<CondicaoPagamentoMonitoramento> CondicoesPagamentoMonitoramento { get; set; }
    public DbSet<AtividadeMonitoramento> AtividadesMonitoramento { get; set; }
    public DbSet<TabelaPrecoMonitoramento> TabelasPrecosMonitoramento { get; set; }

    // Heartbeat
    public DbSet<Heartbeat> Heartbeats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        MapEntity<ClienteMonitoramento>(modelBuilder,    "CONECTA_CLIPEN", "CLI");
        MapEntity<TituloMonitoramento>(modelBuilder,     "CONECTA_TTLPEN", "TTL");
        MapEntity<TributacaoMonitoramento>(modelBuilder, "CONECTA_TRBPEN", "TRB");
        MapEntity<CredencialMonitoramento>(modelBuilder, "CONECTA_CRDPEN", "CRD");
        MapEntity<PedidoMonitoramento>(modelBuilder,     "CONECTA_PEDPEN", "PED");
        MapEntity<ProdutoMonitoramento>(modelBuilder,    "CONECTA_PRDPEN", "PRD");
        MapEntity<EstoqueMonitoramento>(modelBuilder,    "CONECTA_ESTPEN", "EST");
        MapEntity<PrecoMonitoramento>(modelBuilder,      "CONECTA_PRCPEN", "PRC");
        MapEntity<NfeMonitoramento>(modelBuilder,        "CONECTA_NFEPEN", "NFE");
        MapEntity<LimiteCreditoMonitoramento>(modelBuilder,     "CONECTA_LMCPEN", "LMC");
        MapEntity<TransportadoraMonitoramento>(modelBuilder,    "CONECTA_TRAPEN", "TRA");
        MapEntity<CondicaoPagamentoMonitoramento>(modelBuilder, "CONECTA_CDPPEN", "CDP");
        MapEntity<AtividadeMonitoramento>(modelBuilder,  "CONECTA_ATVPEN", "ATV");
        MapEntity<TabelaPrecoMonitoramento>(modelBuilder,"CONECTA_TBPPEN", "TBP");

        modelBuilder.Entity<Heartbeat>(entity =>
        {
            entity.ToTable("HRTBEN");
            entity.Property(e => e.Id).HasColumnName("HRT_CODPEN");
            entity.Property(e => e.NomeWorkflow).HasColumnName("HRT_NOMWFL");            
            entity.Property(e => e.UltimaExecucao).HasColumnName("HRT_DHUEXE");
            entity.Property(e => e.UltimoSucesso).HasColumnName("HRT_DHUSUC");   
            entity.Property(e => e.CicloEsperadoSegundos).HasColumnName("HRT_CICSEG");
        });
    }

    private static void MapEntity<T>(ModelBuilder modelBuilder, string tabela, string prefixo)
        where T : MonitoramentoBase
    {
        modelBuilder.Entity<T>(entity =>
        {
            entity.ToTable(tabela);
            entity.Property(e => e.Id).HasColumnName($"{prefixo}_CODPEN");
            entity.Property(e => e.NomeCliente).HasColumnName($"{prefixo}_NOMCLI");
            entity.Property(e => e.Plataforma).HasColumnName($"{prefixo}_NOMPLA");
            entity.Property(e => e.DataRegistro).HasColumnName($"{prefixo}_DHUALT");
            entity.Property(e => e.Erro).HasColumnName($"{prefixo}_LOGERR");
            entity.Property(e => e.CodigoExterno).HasColumnName($"{prefixo}_CODEXT");
            entity.Property(e => e.CodigoInterno).HasColumnName($"{prefixo}_CODPLA");
            entity.Property(e => e.NomeWorkflow).HasColumnName($"{prefixo}_NOMWFL");
        });
    }
}
