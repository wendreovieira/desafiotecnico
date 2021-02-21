#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DesafioTecnico.ApiCalculaJuros/DesafioTecnico.ApiCalculaJuros.csproj", "DesafioTecnico.ApiCalculaJuros/"]
COPY ["DesafioTecnico.Domain/DesafioTecnico.Domain.csproj", "DesafioTecnico.Domain/"]
COPY ["DesafioTecnico.ApiTaxaJuros/DesafioTecnico.ApiTaxaJuros.csproj", "DesafioTecnico.ApiTaxaJuros/"]
RUN dotnet restore "DesafioTecnico.ApiCalculaJuros/DesafioTecnico.ApiCalculaJuros.csproj"
COPY . .
WORKDIR "/src/DesafioTecnico.ApiCalculaJuros"
RUN dotnet build "DesafioTecnico.ApiCalculaJuros.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioTecnico.ApiCalculaJuros.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioTecnico.ApiCalculaJuros.dll"]