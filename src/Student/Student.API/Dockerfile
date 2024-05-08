#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Student/Student.API/Student.API.csproj", "src/Student/Student.API/"]
COPY ["src/Student/Student.Application/Student.Application.csproj", "src/Student/Student.Application/"]
COPY ["src/Student/Student.Domain/Student.Domain.csproj", "src/Student/Student.Domain/"]
COPY ["src/Student/Student.Infrastructure/Student.Infrastructure.csproj", "src/Student/Student.Infrastructure/"]
RUN dotnet restore "./src/Student/Student.API/Student.API.csproj"
COPY . .
WORKDIR "/src/src/Student/Student.API"
RUN dotnet build "./Student.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Student.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Student.API.dll"]