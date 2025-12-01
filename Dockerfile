# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar csproj de ambos proyectos para el restore
COPY ["DPA.Ecommerce.API/DPA.Ecommerce.API.csproj", "DPA.Ecommerce.API/"]
COPY ["DPA.Ecommerce.CORE/DPA.Ecommerce.CORE.csproj", "DPA.Ecommerce.CORE/"]

# Restore
RUN dotnet restore "DPA.Ecommerce.API/DPA.Ecommerce.API.csproj"

# Copiar el resto del código
COPY . .

# Publicar
RUN dotnet publish "DPA.Ecommerce.API/DPA.Ecommerce.API.csproj" -c Release -o /app/publish

# Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5248

COPY --from=build /app/publish .

EXPOSE 5248

ENTRYPOINT ["dotnet", "DPA.Ecommerce.API.dll"]
