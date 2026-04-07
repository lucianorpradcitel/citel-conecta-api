using Citel.Conecta.Api.Dtos;

namespace Citel.Conecta.Api.Services
{
    public interface IAuthService
    {
        LoginResponse? Login(LoginRequest request);
    }
}
