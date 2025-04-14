# 🌤️ SkyVibe – Väderapplikations-API

SkyVibe är ett API som låter användare hämta och spara aktuell väderinformation, koppla prognoser till olika platser och logga väderdata – allt via ett modernt ASP.NET Core Web API. Fokus ligger på användarvänlighet, stabilitet och förberedelse för framtida frontend-appar (webb/mobil).

---

### 1. Functional Requirements

**Registrering & Inloggning (JWT):**  
Användare kan skapa ett konto och logga in för att få åtkomst till skyddade väderendpoints.

**Hantera Platser (Locations):**  
Skapa, läsa, uppdatera och ta bort platser som du vill koppla väderdata till.

**Aktuell Väderinformation (Current Weather):**  
Spara och hämta aktuell väderdata (temperatur, beskrivning, tidpunkt) per plats.

**7-dagars Prognos (Forecast):**  
Användare kan spara och läsa väderprognoser per dag, kopplat till platser.

**Seed-data (Bogus):**  
Om databasen är tom skapas testdata automatiskt vid uppstart.

**Swagger-dokumentation:**  
Alla endpoints är dokumenterade och testbara direkt i Swagger UI.

**Validering med FluentValidation:**  
Alla inputs till API:et valideras med tydliga felmeddelanden vid ogiltig data.

---

### 2. Non-Functional Requirements

**Prestanda:**  
CRUD-operationer ska svara snabbt och konsekvent vid testning i Swagger/Postman.

**Säkerhet:**  
Alla skyddade endpoints kräver JWT. Lösenord hash:as korrekt. Ingen känslig data i klartext.

**Skalbarhet:**  
API:et är byggt med lagerarkitektur, vilket gör det enkelt att lägga till nya funktioner eller koppla på externa vädertjänster.

**Användarvänlighet (API):**  
Swagger UI visar alla endpoints, förväntade parametrar och svar – vilket gör det enkelt att förstå API:et utan frontend.

**Tillgänglighet:**  
API:et är testat lokalt men kan enkelt deployas till molnet (t.ex. Azure App Service).

---

### 3. Requirements Prioritization (MoSCoW)

**Must Have:**
- JWT-autentisering (register/login)
- CRUD för Location, CurrentWeather och Forecast
- Swagger-dokumentation
- FluentValidation för alla DTOs
- Bogus-seeddata för utveckling/test

**Should Have:**
- Externt API-integration (t.ex. OpenWeatherMap)
- Filter/sortering via query-parametrar
- Rollhantering (User/Admin)
- AutoMapper

**Could Have:**
- Geo-baserad platsidentifiering
- Statistik (medeltemp, kallaste dagen osv)

**Won’t Have:**
- Frontend/webbgränssnitt (kan kopplas på senare)
- Pushnotiser eller vädervarningar (för framtida versioner)
