# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore to leverage Docker cache for dependencies
COPY ["DPA.Ecommerce.API/DPA.Ecommerce.API.csproj", "DPA.Ecommerce.API/"]
RUN dotnet restore "DPA.Ecommerce.API/DPA.Ecommerce.API.csproj"

# Copy remaining sources and publish
COPY . .
RUN dotnet publish "DPA.Ecommerce.API/DPA.Ecommerce.API.csproj" -c Release -o /app/publish --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Expose the same URL/port used during development
ENV ASPNETCORE_URLS=http://+:5248

COPY --from=build /app/publish .

# Create a non-root user and set ownership
RUN adduser --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

EXPOSE 5248
ENTRYPOINT ["dotnet", "DPA.Ecommerce.API.dll"]
