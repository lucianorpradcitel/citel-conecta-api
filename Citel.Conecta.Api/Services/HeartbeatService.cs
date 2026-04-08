using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Citel.Conecta.Api.Services
{
    public class HeartbeatService : IHeartbeatService
    {
        private readonly AppDbContext _context;

        public HeartbeatService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<HeartbeatResponse> RegistrarAsync(HeartbeatRequest request)
        {
            var existente = await _context.Heartbeats
                .FirstOrDefaultAsync(h => h.NomeWorkflow == request.NomeWorkflow);

            if (existente is null)
            {
                existente = new Heartbeat
                {
                    NomeWorkflow = request.NomeWorkflow,                    
                    CicloEsperadoSegundos = request.CicloEsperadoSegundos
                };
                _context.Heartbeats.Add(existente);
            }

            existente.UltimaExecucao = DateTime.UtcNow;
            existente.UltimoSucesso = DateTime.UtcNow;
            existente.CicloEsperadoSegundos = request.CicloEsperadoSegundos;
            
            await _context.SaveChangesAsync();
            return ToResponse(existente);
        }

        public async Task<IEnumerable<HeartbeatResponse>> ObterTodosAsync()
        {
            var lista = await _context.Heartbeats.OrderBy(h => h.NomeWorkflow).ToListAsync();
            return lista.Select(ToResponse);
        }

        public async Task<HeartbeatResponse?> ObterPorWorkflowAsync(string nomeWorkflow)
        {
            var hb = await _context.Heartbeats
                .FirstOrDefaultAsync(h => h.NomeWorkflow == nomeWorkflow);
            return hb is null ? null : ToResponse(hb);
        }

        private static HeartbeatResponse ToResponse(Heartbeat h)
        {
            var status = CalcularStatus(h);
            return new HeartbeatResponse(
                h.Id, h.NomeWorkflow,
                h.UltimaExecucao, h.UltimoSucesso,
                h.CicloEsperadoSegundos,
                status);
        }

        public static string CalcularStatus(Heartbeat h)
        {
            if (h.UltimaExecucao == default)
                return "ATRASADO";

            var segundosDecorridos = (DateTime.UtcNow - h.UltimaExecucao).TotalSeconds;

            if (segundosDecorridos > h.CicloEsperadoSegundos * 2.0)
                return "ATRASADO";

            return "OK";
        }
    }
}
