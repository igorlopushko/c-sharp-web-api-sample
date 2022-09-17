FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY WebApplication11.sln ./
COPY WebApplication11/*.csproj ./WebApplication11/
COPY WebApplication11.Core/*.csproj ./WebApplication11.Core/
COPY WebApplication11.Infrastructure/*.csproj ./WebApplication11.Infrastructure/

RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish WebApplication11.sln -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

ENV ASPNETCORE_URLS=http://*:8080
ENV ASPNETCORE_ENVIRONMENT=Development

USER 1000

WORKDIR /app
COPY --from=build-env /app/out .

EXPOSE 8080
ENTRYPOINT ["dotnet", "WebApplication11.dll"]