# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# 1. Kopier filer og restore
COPY . .
RUN dotnet restore

# 2. Installer den frittstående Tailwind-klienten (Standalone CLI)
# Dette gjør at "tailwindcss" kommandoen fungerer uten Node.js
RUN curl -sLO https://github.com/tailwindlabs/tailwindcss/releases/download/v4.1.18/tailwindcss-linux-x64 \
    && chmod +x tailwindcss-linux-x64 \
    && mv tailwindcss-linux-x64 /usr/bin/tailwindcss

# 3. Bygg og publiser prosjektet
# Nå vil "tailwindcss" bli funnet av dotnet-prosessen
RUN dotnet publish -c Release -o /app

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .

# Standard port for .NET i container
ENV ASPNETCORE_URLS=http://+:80

# Start applikasjonen
ENTRYPOINT ["dotnet", "BandApp.dll"]
