using Citel.Conecta.Api.Dtos;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Citel.Conecta.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var response = _authService.Login(request);
            if (response is null)
                return Unauthorized(new { mensagem = "Usuário ou senha inválidos." });

            return Ok(response);
        }
    }
}
