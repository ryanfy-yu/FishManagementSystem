#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY . .

#COPY ["FishManagementSystem.SSO/FishManagementSystem.SSO.csproj", "FishManagementSystem.SSO/"]
#COPY ["FishManagementSystem.AOP/FishManagementSystem.AOP.csproj", "FishManagementSystem.AOP/"]
#COPY ["FishManagementSystem.Commons/FishManagementSystem.Commons.csproj", "FishManagementSystem.Commons/"]
#COPY ["FishManagementSystem.IoC/FishManagementSystem.IoC.csproj", "FishManagementSystem.IoC/"]
#COPY ["FishManagementSystem.BusinessService/FishManagementSystem.BusinessService.csproj", "FishManagementSystem.BusinessService/"]
#COPY ["FishManagementSystem.DBModels/FishManagementSystem.DBModels.csproj", "FishManagementSystem.DBModels/"]
#COPY ["FishManagementSystem.IDBModels/FishManagementSystem.IDBModels.csproj", "FishManagementSystem.IDBModels/"]
#COPY ["FishManagementSystem.IBussinessService/FishManagementSystem.IBussinessService.csproj", "FishManagementSystem.IBussinessService/"]
#COPY ["FishManagementSystem.Mapping/FishManagementSystem.Mapping.csproj", "FishManagementSystem.Mapping/"]
#COPY ["FishManagementSystem.DTO/FishManagementSystem.DTO.csproj", "FishManagementSystem.DTO/"]
#COPY ["FishManagementSystem.JWT/FishManagementSystem.JWT.csproj", "FishManagementSystem.JWT/"]
#COPY ["FishManagementSystem.Swagger/FishManagementSystem.Swagger.csproj", "FishManagementSystem.Swagger/"]
RUN dotnet restore "./FishManagementSystem.SSO/FishManagementSystem.SSO.csproj"
COPY . .
WORKDIR "/src/FishManagementSystem.SSO"
RUN dotnet build "./FishManagementSystem.SSO.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./FishManagementSystem.SSO.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FishManagementSystem.SSO.dll"]