# BandApp

En fullstack-applikasjon designet for å hjelpe band med å diskutere, dele filer og samarbeide om musikkprosjekter.

Prosjektet er laget som en øvelse i fullstack-utvikling med Microsoft-teknologier og moderne frontend-styling.

## Funksjoner (Nåværende status)

*   **Brukerautentisering:** Sikker innlogging og registrering av brukere.
*   **Database:** Bruker SQLite for enkel, lokal datalagring.

## Teknologi (Tech Stack)

Dette prosjektet er bygget med følgende teknologier:

*   **Backend:** ASP.NET Core (C#)
*   **Database:** Entity Framework Core med SQLite
*   **Frontend Styling:** Tailwind CSS
*   **Frontend Logikk:** Ren HTML, CSS og JavaScript

## Installasjon og bruk (Lokal Kjøring)

For å kjøre denne applikasjonen lokalt trenger du [.NET 8.0 SDK](dotnet.microsoft.com) (eller nyere) installert.

1.  **Klon** repositoryet:
    ```bash
    https://github.com/GargusS/BandApp.git
    ```

2.  **Naviger** til prosjektmappen:
    ```bash
    cd BandApp
    ```

3.  **Kjør database-migrasjoner** for å opprette SQLite-databasen:
    ```bash
    dotnet ef database update
    ```

4.  **Kjør applikasjonen:**
    ```bash
    dotnet run
    ```
    Appen vil da være tilgjengelig på f.eks. `https://localhost:5001` (eller en annen lokal port spesifisert av .NET CLI).

## Kredittering

Dette prosjektet er utviklet av [GargusS](https://github.com/GargusS).

## Lisens

Dette prosjektet er lisensiert under [MIT-lisensen](opensource.org). Siden er ment for øvingsformål, og du står fritt til å bruke koden som du vil.
