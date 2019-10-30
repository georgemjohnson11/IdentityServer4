FROM mcr.microsoft.com/dotnet/core/sdk:2.2-alpine AS builder
WORKDIR /app

# Copy solution and restore as distinct layers to cache dependencies
COPY ./Stocks.Auth/*.csproj ./Stocks.Auth/
COPY *.sln ./
RUN dotnet restore

# Publish the application
COPY . ./
WORKDIR /app/Stocks.Auth
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-alpine AS runtime
WORKDIR /app
COPY --from=builder /app/Stocks.Auth/out .
ENTRYPOINT ["dotnet", "Stocks.Auth.dll"]

# Sample build command
# docker build -t codingmilitia/auth .