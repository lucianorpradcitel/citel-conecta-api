using System.Text;
using Citel.Conecta.Api.Data;
using Citel.Conecta.Api.Middleware;
using Citel.Conecta.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// Entidades originais
builder.Services.AddScoped<IClienteMonitoramentoService, ClienteMonitoramentoService>();
builder.Services.AddScoped<ITituloMonitoramentoService, TituloMonitoramentoService>();
builder.Services.AddScoped<ITributacaoMonitoramentoService, TributacaoMonitoramentoService>();

// Novas entidades
builder.Services.AddScoped<ICredencialMonitoramentoService, CredencialMonitoramentoService>();
builder.Services.AddScoped<IPedidoMonitoramentoService, PedidoMonitoramentoService>();
builder.Services.AddScoped<IProdutoMonitoramentoService, ProdutoMonitoramentoService>();
builder.Services.AddScoped<IEstoqueMonitoramentoService, EstoqueMonitoramentoService>();
builder.Services.AddScoped<IPrecoMonitoramentoService, PrecoMonitoramentoService>();
builder.Services.AddScoped<INfeMonitoramentoService, NfeMonitoramentoService>();
builder.Services.AddScoped<ILimiteCreditoMonitoramentoService, LimiteCreditoMonitoramentoService>();
builder.Services.AddScoped<ITransportadoraMonitoramentoService, TransportadoraMonitoramentoService>();
builder.Services.AddScoped<ICondicaoPagamentoMonitoramentoService, CondicaoPagamentoMonitoramentoService>();
builder.Services.AddScoped<IAtividadeMonitoramentoService, AtividadeMonitoramentoService>();
builder.Services.AddScoped<ITabelaPrecoMonitoramentoService, TabelaPrecoMonitoramentoService>();

// Heartbeat + Resumo + Auth
builder.Services.AddScoped<IHeartbeatService, HeartbeatService>();
builder.Services.AddScoped<IResumoService, ResumoService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// --- JWT ---
var jwtSecret = builder.Configuration["Jwt:Secret"]!;
var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;
var jwtAudience = builder.Configuration["Jwt:Audience"]!;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Citel Conecta API",
        Version = "v1",
        Description = "API de monitoramento de integrações - Mercos, Shopify e ERP"
    });

    options.EnableAnnotations();

    var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Informe o token JWT: Bearer {token}"
    };
    options.AddSecurityDefinition("Bearer", securityScheme);
    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// --- CORS ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodos", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// =============================================
// SEÇÃO 2: PIPELINE HTTP (MIDDLEWARE)
// A ordem aqui importa! Cada request passa por
// esses middlewares na ordem que estão registrados.
// É como uma fila: o request entra pelo primeiro
// e vai descendo até chegar no controller.
// =============================================

// 1° — Exceções globais (tem que ser o primeiro!)
app.UseMiddleware<GlobalExceptionMiddleware>();

// 2° — Swagger (fora do if para funcionar em todos os ambientes)
app.UseSwagger(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0;
}); app.UseSwaggerUI();

// 3° — CORS (antes de auth, senão o preflight falha)
app.UseCors("PermitirTodos");

// 4° — Redirecionamento HTTPS
app.UseHttpsRedirection();

// 5° — Autenticação e Autorização
app.UseAuthentication();
app.UseAuthorization();

// 6° — Arquivos estáticos do React (wwwroot)
app.UseDefaultFiles();
app.UseStaticFiles();

// 7° — Mapeia os controllers (rotas /api/*)
app.MapControllers();

// 8° — Fallback: qualquer rota não-API devolve o index.html do React
app.MapFallbackToFile("index.html");

app.Run();