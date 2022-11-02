#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["GrpcClient/GrpcClient.csproj", "GrpcClient/"]
RUN dotnet restore "GrpcClient/GrpcClient.csproj"
COPY . .
WORKDIR "/src/GrpcClient"
RUN dotnet build "GrpcClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GrpcClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcClient.dll"]