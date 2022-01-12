#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MyFinances.API/MyFinances.API.csproj", "src/MyFinances.API/"]
COPY ["src/MyFinances.Infra/MyFinances.Infra.csproj", "src/MyFinances.Infra/"]
COPY ["src/MyFinances.Core/MyFinances.Core.csproj", "src/MyFinances.Core/"]
RUN dotnet restore "src/MyFinances.API/MyFinances.API.csproj"
COPY . .
WORKDIR "/src/src/MyFinances.API"
RUN dotnet build "MyFinances.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyFinances.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFinances.API.dll"]
