using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Citel.Conecta.Api.Services
{
    public abstract class MonitoramentoServiceBase<TEntity, TRequest, TResponse>
        : IMonitoramentoServiceBase<TRequest, TResponse>
        where TEntity : MonitoramentoBase, new()
        where TRequest : MonitoramentoRequestBase
        where TResponse : MonitoramentoResponseBase
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        protected MonitoramentoServiceBase(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        protected abstract TResponse ToResponse(TEntity entity);

        public async Task<TResponse> RegistrarAsync(TRequest request)
        {
            var existente = await _dbSet.FirstOrDefaultAsync(e =>
                e.NomeCliente == request.NomeCliente &&
                e.Plataforma == request.Plataforma &&
                e.CodigoExterno == request.CodigoExterno &&
                e.CodigoInterno == request.CodigoInterno);

            if (existente is null)
            {
                var entidade = new TEntity
                {
                    NomeCliente = request.NomeCliente,
                    Plataforma = request.Plataforma,
                    Erro = request.Erro,
                    DataRegistro = DateTime.UtcNow,
                    CodigoExterno = request.CodigoExterno,
                    CodigoInterno = request.CodigoInterno,
                    NomeWorkflow = request.NomeWorkflow
                };

                _dbSet.Add(entidade);
                await _context.SaveChangesAsync();
                return ToResponse(entidade);
            }

            // Upsert: atualiza erro, data e workflow
            existente.Erro = request.Erro;
            existente.DataRegistro = DateTime.UtcNow;
            existente.NomeWorkflow = request.NomeWorkflow;
            await _context.SaveChangesAsync();
            return ToResponse(existente);
        }

        public async Task RemoverAsync(long id)
        {
            var registro = await _dbSet.FindAsync(id);
            if (registro is null)
                throw new ArgumentException("Registro não encontrado");

            _dbSet.Remove(registro);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TResponse>> ObterTodosAsync(
            string? plataforma = null,
            string? nomeCliente = null,
            string? nomeWorkflow = null,
            string? codigoExterno = null,
            DateTime? dataInicio = null,
            DateTime? dataFim = null,
            int pagina = 1,
            int tamanhoPagina = 50)
        {
            var query = _dbSet.AsQueryable();

            if (!string.IsNullOrEmpty(plataforma))
                query = query.Where(e => e.Plataforma == plataforma);

            if (!string.IsNullOrEmpty(nomeCliente))
                query = query.Where(e => e.NomeCliente == nomeCliente);

            if (!string.IsNullOrEmpty(nomeWorkflow))
                query = query.Where(e => e.NomeWorkflow == nomeWorkflow);

            if (!string.IsNullOrEmpty(codigoExterno))
                query = query.Where(e => e.CodigoExterno == codigoExterno);

            if (dataInicio.HasValue)
                query = query.Where(e => e.DataRegistro >= dataInicio.Value);

            if (dataFim.HasValue)
                query = query.Where(e => e.DataRegistro <= dataFim.Value);

            var resultado = await query
                .OrderByDescending(e => e.DataRegistro)
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .ToListAsync();

            return resultado.Select(ToResponse);
        }
    }
}
