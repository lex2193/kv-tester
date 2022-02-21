#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["KvTester/KvTester.csproj", "KvTester/"]
RUN dotnet restore "KvTester/KvTester.csproj"
COPY . .
WORKDIR "/src/KvTester"
RUN dotnet build "KvTester.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KvTester.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KvTester.dll"]
