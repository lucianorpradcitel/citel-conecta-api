using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Citel.Conecta.Api.Services
{
    public class ResumoService : IResumoService
    {
        private readonly AppDbContext _context;

        public ResumoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResumoResponse> ObterResumoAsync()
        {
            // Contagem de erros por entidade e por plataforma
            var entidades = new List<(string nome, string tipoEntidade, int erros, IEnumerable<(string plataforma, int count)> porPlataforma)>
            {
                await ContarErros("credenciais", "CREDENCIAL", _context.CredenciaisMonitoramento),
                await ContarErros("pedidos",     "PEDIDO",     _context.PedidosMonitoramento),
                await ContarErros("produtos",    "PRODUTO",    _context.ProdutosMonitoramento),
                await ContarErros("estoques",    "ESTOQUE",    _context.EstoquesMonitoramento),
                await ContarErros("precos",      "PRECO",      _context.PrecosMonitoramento),
                await ContarErros("nfe",         "NFE",        _context.NfesMonitoramento),
                await ContarErros("limites-credito",      "LIMITE_CREDITO",      _context.LimitesCreditorMonitoramento),
                await ContarErros("transportadoras",      "TRANSPORTADORA",      _context.TransportadorasMonitoramento),
                await ContarErros("condicoes-pagamento",  "CONDICAO_PAGAMENTO",  _context.CondicoesPagamentoMonitoramento),
                await ContarErros("atividades",           "ATIVIDADE",           _context.AtividadesMonitoramento),
                await ContarErros("tabelas-preco",        "TABELA_PRECO",        _context.TabelasPrecosMonitoramento),
                await ContarErros("clientes",    "CLIENTE",    _context.ClientesMonitoramento),
                await ContarErros("titulos",     "TITULO",     _context.TitulosMonitoramento),
                await ContarErros("tributacoes", "TRIBUTACAO", _context.TributacoesMonitoramento),
            };

            var heartbeats = await _context.Heartbeats.ToListAsync();
            var heartbeatPorTipo = heartbeats.ToDictionary(h => h.TipoEntidade, h => h);

            var porEntidade = entidades.Select(e =>
            {
                heartbeatPorTipo.TryGetValue(e.tipoEntidade, out var hb);
                var ultimoSucesso = hb?.UltimoSucesso;
                var hbStatus = hb is null ? "FALHA" : HeartbeatService.CalcularStatus(hb);
                var status = CalcularCorStatus(e.erros, hbStatus);
                return new EntidadeResumo(e.nome, e.erros, ultimoSucesso, status);
            }).ToList();

            var totalErros = entidades.Sum(e => e.erros);

            var porPlataforma = entidades
                .SelectMany(e => e.porPlataforma)
                .GroupBy(x => x.plataforma)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.count));

            var credenciaisOk = porEntidade.FirstOrDefault(e => e.Entidade == "credenciais")?.Status == "verde";

            return new ResumoResponse(totalErros, porEntidade, porPlataforma, credenciaisOk);
        }

        private static async Task<(string nome, string tipoEntidade, int erros, IEnumerable<(string, int)> porPlataforma)>
            ContarErros<T>(string nome, string tipoEntidade, DbSet<T> dbSet) where T : MonitoramentoBase
        {
            var registros = await dbSet.Select(e => e.Plataforma).ToListAsync();
            var erros = registros.Count;
            var porPlataforma = registros
                .GroupBy(p => p)
                .Select(g => (g.Key, g.Count()))
                .ToList();
            return (nome, tipoEntidade, erros, porPlataforma);
        }

        private static string CalcularCorStatus(int errosAtivos, string hbStatus) =>
            hbStatus == "FALHA" ? "vermelho" :
            hbStatus == "ATRASADO" || errosAtivos > 0 ? "amarelo" :
            "verde";
    }
}
