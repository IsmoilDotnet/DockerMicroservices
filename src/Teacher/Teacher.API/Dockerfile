#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Teacher/Teacher.API/Teacher.API.csproj", "src/Teacher/Teacher.API/"]
COPY ["src/Teacher/Teacher.Application/Teacher.Application.csproj", "src/Teacher/Teacher.Application/"]
COPY ["src/Teacher/Teacher.Domain/Teacher.Domain.csproj", "src/Teacher/Teacher.Domain/"]
COPY ["src/Teacher/Teacher.Infrastructure/Teacher.Infrastructure.csproj", "src/Teacher/Teacher.Infrastructure/"]
RUN dotnet restore "./src/Teacher/Teacher.API/Teacher.API.csproj"
COPY . .
WORKDIR "/src/src/Teacher/Teacher.API"
RUN dotnet build "./Teacher.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Teacher.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teacher.API.dll"]