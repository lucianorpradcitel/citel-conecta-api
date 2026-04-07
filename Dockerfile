# ── Stage 1: Build ──────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o .csproj e restaura dependências (cache layer)
COPY Citel.Conecta.Api/Citel.Conecta.Api.csproj ./Citel.Conecta.Api/
RUN dotnet restore ./Citel.Conecta.Api/Citel.Conecta.Api.csproj

# Copia todo o restante e publica
COPY Citel.Conecta.Api/ ./Citel.Conecta.Api/
RUN dotnet publish ./Citel.Conecta.Api/Citel.Conecta.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ── Stage 2: Runtime ─────────────────────────────────────────────────────────
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os artefatos do build
COPY --from=build /app/publish .

# Porta da aplicação
EXPOSE 8080

# Variáveis de ambiente padrão (sobrescritas pelo Portainer/docker-compose)
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "Citel.Conecta.Api.dll"]
