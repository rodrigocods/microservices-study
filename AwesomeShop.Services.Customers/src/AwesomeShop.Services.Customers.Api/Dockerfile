FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5002

ENV ASPNETCORE_URLS=http://+:5002

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:5.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/AwesomeShop.Services.Customers.Api/AwesomeShop.Services.Customers.Api.csproj", "src/AwesomeShop.Services.Customers.Api/"]
RUN dotnet restore "src/AwesomeShop.Services.Customers.Api/AwesomeShop.Services.Customers.Api.csproj"
COPY . .
WORKDIR "/src/src/AwesomeShop.Services.Customers.Api"
RUN dotnet build "AwesomeShop.Services.Customers.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "AwesomeShop.Services.Customers.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeShop.Services.Customers.Api.dll"]
