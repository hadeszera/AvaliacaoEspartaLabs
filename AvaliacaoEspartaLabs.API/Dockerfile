#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AvaliacaoEspartaLabs.API/AvaliacaoEspartaLabs.API.csproj", "AvaliacaoEspartaLabs.API/"]
COPY ["Infra/AvaliacaoEspartaLabs.Infra/AvaliacaoEspartaLabs.Infra.csproj", "Infra/AvaliacaoEspartaLabs.Infra/"]
COPY ["Domain/AvaliacaoEspartaLabs.Domain/AvaliacaoEspartaLabs.Domain.csproj", "Domain/AvaliacaoEspartaLabs.Domain/"]
COPY ["../Application/AvaliacaoEspartaLabs.Application/AvaliacaoEspartaLabs.Application.csproj", "../Application/AvaliacaoEspartaLabs.Application/"]
COPY ["Service/AvaliacaoEspartaLabs.Service/AvaliacaoEspartaLabs.Service.csproj", "Service/AvaliacaoEspartaLabs.Service/"]
RUN dotnet restore "AvaliacaoEspartaLabs.API/AvaliacaoEspartaLabs.API.csproj"
COPY . .
WORKDIR "/src/AvaliacaoEspartaLabs.API"
RUN dotnet build "AvaliacaoEspartaLabs.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AvaliacaoEspartaLabs.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AvaliacaoEspartaLabs.API.dll"]
