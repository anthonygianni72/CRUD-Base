#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjetoBase1/ProjetoBase1.csproj", "ProjetoBase1/"]
RUN dotnet restore "ProjetoBase1/ProjetoBase1.csproj"
COPY . .
WORKDIR "/src/ProjetoBase1"
RUN dotnet build "ProjetoBase1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjetoBase1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjetoBase1.dll"]
#ENTRYPOINT dotnet watch run --no-restore