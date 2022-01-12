#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/MyFinances.Blazor/Server/MyFinances.Blazor.Server.csproj", "src/MyFinances.Blazor/Server/"]
COPY ["src/MyFinances.Blazor/Shared/MyFinances.Blazor.Shared.csproj", "src/MyFinances.Blazor/Shared/"]
COPY ["src/MyFinances.Blazor/Client/MyFinances.Blazor.Client.csproj", "src/MyFinances.Blazor/Client/"]
RUN dotnet restore "src/MyFinances.Blazor/Server/MyFinances.Blazor.Server.csproj"
COPY . .
WORKDIR "/src/src/MyFinances.Blazor/Server"
RUN dotnet build "MyFinances.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyFinances.Blazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFinances.Blazor.Server.dll"]