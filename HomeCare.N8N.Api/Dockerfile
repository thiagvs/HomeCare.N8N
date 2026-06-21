# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["HomeCare.N8N.Api/HomeCare.N8N.Api.csproj", "HomeCare.N8N.Api/"]
COPY ["HomeCare.N8N.Data/HomeCare.N8N.Data.csproj", "HomeCare.N8N.Data/"]
COPY ["HomeCare.N8N.Application/HomeCare.N8N.Application.csproj", "HomeCare.N8N.Application/"]
RUN dotnet restore "./HomeCare.N8N.Api/HomeCare.N8N.Api.csproj"
COPY . .
WORKDIR "/src/HomeCare.N8N.Api"
RUN dotnet build "./HomeCare.N8N.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./HomeCare.N8N.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeCare.N8N.Api.dll"]