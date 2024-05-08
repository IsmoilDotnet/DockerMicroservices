#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Admin/Admin.API/Admin.API.csproj", "src/Admin/Admin.API/"]
COPY ["src/Admin/Admin.Application/Admin.Application.csproj", "src/Admin/Admin.Application/"]
COPY ["src/Admin/Admin.Domain/Admin.Domain.csproj", "src/Admin/Admin.Domain/"]
COPY ["src/Admin/Admin.Infrastructure/Admin.Infrastructure.csproj", "src/Admin/Admin.Infrastructure/"]
RUN dotnet restore "./src/Admin/Admin.API/Admin.API.csproj"
COPY . .
WORKDIR "/src/src/Admin/Admin.API"
RUN dotnet build "./Admin.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Admin.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Admin.API.dll"]