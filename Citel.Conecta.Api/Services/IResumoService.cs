using Citel.Conecta.Api.Dtos;

namespace Citel.Conecta.Api.Services
{
    public interface IResumoService
    {
        Task<ResumoResponse> ObterResumoAsync();
    }
}
