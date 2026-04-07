using Citel.Conecta.Api.Dtos;

namespace Citel.Conecta.Api.Services
{
    public interface IHeartbeatService
    {
        Task<HeartbeatResponse> RegistrarAsync(HeartbeatRequest request);
        Task<IEnumerable<HeartbeatResponse>> ObterTodosAsync();
        Task<HeartbeatResponse?> ObterPorWorkflowAsync(string nomeWorkflow);
    }
}
