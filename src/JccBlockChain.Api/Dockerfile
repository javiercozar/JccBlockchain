FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/JccBlockChain.Api/JccBlockChain.Api.csproj", "src/JccBlockChain.Api/"]
RUN dotnet restore "src/JccBlockChain.Api/JccBlockChain.Api.csproj"
COPY . .
WORKDIR "/src/src/JccBlockChain.Api"
RUN dotnet build "JccBlockChain.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JccBlockChain.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JccBlockChain.Api.dll"]
