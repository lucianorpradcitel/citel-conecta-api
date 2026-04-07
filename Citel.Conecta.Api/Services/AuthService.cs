using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Citel.Conecta.Api.Dtos;
using Microsoft.IdentityModel.Tokens;

namespace Citel.Conecta.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoginResponse? Login(LoginRequest request)
        {
            var usuarioEsperado = _configuration["Jwt:Usuario"];
            var senhaHash = _configuration["Jwt:SenhaHash"];

            if (request.Usuario != usuarioEsperado || !BCrypt.Net.BCrypt.Verify(request.Senha, senhaHash))
                return null;

            var token = GerarToken(request.Usuario);
            return token;
        }

        private LoginResponse GerarToken(string usuario)
        {
            var secret = _configuration["Jwt:Secret"]!;
            var issuer = _configuration["Jwt:Issuer"]!;
            var audience = _configuration["Jwt:Audience"]!;
            var validadeHoras = int.Parse(_configuration["Jwt:ValidadeHoras"] ?? "24");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracao = DateTime.UtcNow.AddHours(validadeHoras);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: expiracao,
                signingCredentials: creds
            );

            return new LoginResponse(new JwtSecurityTokenHandler().WriteToken(token), expiracao);
        }
    }
}
