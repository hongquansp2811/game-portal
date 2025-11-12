# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["GamePortal.Web/GamePortal.Web.csproj", "GamePortal.Web/"]
COPY ["GamePortal.Core/GamePortal.Core.csproj", "GamePortal.Core/"]
COPY ["GamePortal.Infrastructure/GamePortal.Infrastructure.csproj", "GamePortal.Infrastructure/"]

RUN dotnet restore "GamePortal.Web/GamePortal.Web.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/src/GamePortal.Web"
RUN dotnet build "GamePortal.Web.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "GamePortal.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=publish /app/publish .

# Health check - Railway/Render will use healthcheckPath from config
# HEALTHCHECK removed - platforms handle this via healthcheckPath

ENTRYPOINT ["dotnet", "GamePortal.Web.dll"]

