# IT Maintenance Hub

**Patch- & Asset-Management-System für IT-Infrastruktur**

Eine Blazor Server Anwendung (.NET 8.0) zur Verwaltung von IT-Assets, Patch-Zyklen und Wartungsdokumentation.

## Features

### Phase 1 - Asset-Grundlage ✅
- Projekt- und Netzverwaltung (VLANs, Subnetze)
- Asset-Inventar (Server, Netzwerkkomponenten, VMs, iLO)
- Zuständigkeiten pro Projekt/Netz
- Active Directory Integration

### Phase 2 - Patch-Dokumentation 🚧
- 2-wöchige Patch-Zyklen-Verwaltung
- Dokumentation von Updates (Windows, Linux, Firmware)
- Kommentarsystem mit Threading
- Status-Dashboard pro Patch-Zyklus

### Phase 3 - Erweiterungen 📋
- Firmware-Versionstracking
- Automatische Benachrichtigungen
- Compliance-Reports
- API für Monitoring-Integration

## Technologie-Stack

- **Frontend**: Blazor Server, MudBlazor
- **Backend**: ASP.NET Core 8.0, Entity Framework Core
- **Datenbank**: SQL Server / PostgreSQL
- **Authentication**: ASP.NET Core Identity mit AD/LDAP
- **Logging**: Serilog

## Projektstruktur

```
ITMaintenanceHub/
├── src/
│   ├── ITMaintenanceHub.Core/          # Domain Models, Entities
│   ├── ITMaintenanceHub.Infrastructure/ # EF Core, Repositories
│   ├── ITMaintenanceHub.Application/    # Services, DTOs
│   └── ITMaintenanceHub.Web/            # Blazor Server App
└── ITMaintenanceHub.sln
```

## Installation

### Voraussetzungen
- .NET 8.0 SDK
- SQL Server 2019+ oder PostgreSQL 14+
- Optional: Docker für Container-Deployment

### Setup

```bash
# Repository clonen
git clone https://github.com/MaAr389/ITMaintenanceHub.git
cd ITMaintenanceHub

# Abhängigkeiten wiederherstellen
dotnet restore

# Datenbank-Connection-String anpassen
# appsettings.json in ITMaintenanceHub.Web/

# Migration ausführen
cd src/ITMaintenanceHub.Web
dotnet ef database update

# Anwendung starten
dotnet run
```

## Roadmap

Siehe [ROADMAP.md](ROADMAP.md) für detaillierte Planung.

## Lizenz

Apache 2.0 - Siehe [LICENSE](LICENSE)

## Autor

MaAr389 - IT-Systemadministrator
