#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/WebApp.To.Read.Profiler.Logs/WebApp.To.Read.Profiler.Logs.csproj", "src/WebApp.To.Read.Profiler.Logs/"]
COPY ["src/ClassLib.To.Test.Profiling/ClassLib.To.Test.Profiling.csproj", "src/ClassLib.To.Test.Profiling/"]
RUN dotnet restore "src/WebApp.To.Read.Profiler.Logs/WebApp.To.Read.Profiler.Logs.csproj"
COPY . .
WORKDIR "/src/src/WebApp.To.Read.Profiler.Logs"
RUN dotnet build "WebApp.To.Read.Profiler.Logs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp.To.Read.Profiler.Logs.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp.To.Read.Profiler.Logs.dll"]