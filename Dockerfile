
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


ENV System.Drawing.EnableUnixSupport=true

RUN apt-get update && \
    apt-get install -y --allow-unauthenticated libgdiplus libc6-dev



FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["contasoft-api.csproj", "."]
RUN dotnet restore "./contasoft-api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "contasoft-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "contasoft-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENV imagendgii="/opt/contasoft/images/dgii.png"
ENTRYPOINT ["dotnet", "contasoft-api.dll"]