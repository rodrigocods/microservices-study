# Stage for building the application
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy only the project file to restore dependencies
COPY ["AwesomeShop.Services.Payments.Api/AwesomeShop.Services.Payments.Api.csproj", "AwesomeShop.Services.Payments.Api/"]
RUN dotnet restore "AwesomeShop.Services.Payments.Api/AwesomeShop.Services.Payments.Api.csproj"

# Copy the whole project
COPY . .

# Build the project
WORKDIR "/src/AwesomeShop.Services.Payments.Api"
RUN dotnet build -c Release -o /app/build

# Stage for publishing the application
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Final stage for the container
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AwesomeShop.Services.Payments.Api.dll"]
