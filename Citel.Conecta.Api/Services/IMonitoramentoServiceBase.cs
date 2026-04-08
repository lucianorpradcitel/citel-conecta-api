using Citel.Conecta.Api.Dtos;

namespace Citel.Conecta.Api.Services
{
    public interface IMonitoramentoServiceBase<TRequest, TResponse>
        where TRequest : MonitoramentoRequestBase
        where TResponse : MonitoramentoResponseBase
    {
        Task<TResponse> RegistrarAsync(TRequest request);
        Task RemoverAsync(long id);
        Task<IEnumerable<TResponse>> ObterTodosAsync(
            string? plataforma = null,
            string? nomeCliente = null,
            string? nomeWorkflow = null,
            string? codigoExterno = null,
            DateTime? dataInicio = null,
            DateTime? dataFim = null,
            int pagina = 1,
            int tamanhoPagina = 50);
    }
}
