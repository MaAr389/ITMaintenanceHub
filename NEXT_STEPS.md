# Nächste Schritte - IT Maintenance Hub

**Status:** Grundstruktur angelegt ✅

Dieses Dokument enthält die nächsten Schritte zum Aufbau des kompletten Projekts.

---

## ✅ Bereits erledigt

- README.md mit Projektübersicht
- ROADMAP.md mit detaillierter Planung (3 Phasen, 9 Sprints)
- .gitignore für .NET Projekte
- LICENSE (Apache 2.0)
- **src/ITMaintenanceHub.Core/Entities/Asset.cs** (erste Domain Entity)

---

## 🚧 Nächste Schritte (Sprint 1)

### 1. Restliche Domain Models erstellen

Erstelle diese Dateien im Ordner `src/ITMaintenanceHub.Core/Entities/`:

**Jetzt fortfahren:**

1. **Project.cs** - Projekt-Entity
2. **Network.cs** - Netzwerk/VLAN-Entity
3. **PatchCycle.cs** - 2-wöchige Patch-Zyklen
4. **PatchEntry.cs** - Einzelne Patch-Einträge
5. **AssetComment.cs** - Kommentare an Assets
6. **ApplicationUser.cs** - Erweiterte Identity-User
7. **Notification.cs** - Benachrichtigungssystem
8. **AuditLog.cs** - Audit-Trail

### 2. Project-Dateien erstellen

Erstelle die .csproj-Dateien für alle Projekte:

**src/ITMaintenanceHub.Core/ITMaintenanceHub.Core.csproj:**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  
  <ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.0" />
  </ItemGroup>
</Project>
```

**src/ITMaintenanceHub.Infrastructure/ITMaintenanceHub.Infrastructure.csproj:**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  
  <ItemGroup>
    <ProjectReference Include="..\\ITMaintenanceHub.Core\\ITMaintenanceHub.Core.csproj" />
  </ItemGroup>
  
  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.0" />
  </ItemGroup>
</Project>
```

**src/ITMaintenanceHub.Application/ITMaintenanceHub.Application.csproj:**
```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>
  
  <ItemGroup>
    <ProjectReference Include="..\\ITMaintenanceHub.Core\\ITMaintenanceHub.Core.csproj" />
    <ProjectReference Include="..\\ITMaintenanceHub.Infrastructure\\ITMaintenanceHub.Infrastructure.csproj" />
  </ItemGroup>
</Project>
```

**src/ITMaintenanceHub.Web/ITMaintenanceHub.Web.csproj:**
```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  
  <ItemGroup>
    <ProjectReference Include="..\\ITMaintenanceHub.Application\\ITMaintenanceHub.Application.csproj" />
  </ItemGroup>
  
  <ItemGroup>
    <PackageReference Include="MudBlazor" Version="7.0.0" />
    <PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.0" />
  </ItemGroup>
</Project>
```

### 3. Solution-Datei erstellen

**ITMaintenanceHub.sln** (im Root):

```
Microsoft Visual Studio Solution File, Format Version 12.00
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ITMaintenanceHub.Core", "src\\ITMaintenanceHub.Core\\ITMaintenanceHub.Core.csproj", "{GUID-1}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ITMaintenanceHub.Infrastructure", "src\\ITMaintenanceHub.Infrastructure\\ITMaintenanceHub.Infrastructure.csproj", "{GUID-2}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ITMaintenanceHub.Application", "src\\ITMaintenanceHub.Application\\ITMaintenanceHub.Application.csproj", "{GUID-3}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "ITMaintenanceHub.Web", "src\\ITMaintenanceHub.Web\\ITMaintenanceHub.Web.csproj", "{GUID-4}"
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
    EndGlobalSection
EndGlobal
```

*Hinweis: Visual Studio generiert die GUIDs automatisch beim ersten Öffnen.*

### 4. DbContext erstellen

**src/ITMaintenanceHub.Infrastructure/Data/ApplicationDbContext.cs:**

Siehe ursprüngliche Code-Vorlage in den Chat-Protokollen.

### 5. GitHub Actions Workflow

**.github/workflows/dotnet.yml:**
```yaml
name: .NET Build and Test

on:
  push:
    branches: [ main, develop ]
  pull_request:
    branches: [ main ]

jobs:
  build:
    runs-on: ubuntu-latest
    
    steps:
    - uses: actions/checkout@v4
    
    - name: Setup .NET 8
      uses: actions/setup-dotnet@v4
      with:
        dotnet-version: '8.0.x'
    
    - name: Restore
      run: dotnet restore ITMaintenanceHub.sln
    
    - name: Build
      run: dotnet build ITMaintenanceHub.sln --no-restore -c Release
    
    - name: Test
      run: dotnet test --no-build --verbosity normal
```

---

## 💻 Lokale Entwicklung starten

### Voraussetzungen

- .NET 8 SDK
- Visual Studio 2022 oder VS Code + C# Extension
- SQL Server oder Docker (für SQL Server Container)

### Setup-Schritte

```bash
# 1. Repository clonen
git clone https://github.com/MaAr389/ITMaintenanceHub.git
cd ITMaintenanceHub

# 2. Abhängigkeiten wiederherstellen
dotnet restore

# 3. Solution in Visual Studio öffnen
start ITMaintenanceHub.sln

# 4. Datenbank-Migrationen erstellen (sobald DbContext erstellt ist)
cd src/ITMaintenanceHub.Web
dotnet ef migrations add InitialCreate --project ../ITMaintenanceHub.Infrastructure
dotnet ef database update

# 5. Anwendung starten
dotnet run --project src/ITMaintenanceHub.Web
```

---

## 📅 Zeitplan (gemäß ROADMAP.md)

**Sprint 1 (Wochen 1-2): Projektsetup**
- [x] README, ROADMAP, .gitignore
- [ ] Alle Domain Models
- [ ] Solution & Projects
- [ ] DbContext

**Sprint 2 (Wochen 3-4): Grundlegende UI**
- [ ] Repository Pattern
- [ ] Projekt-/Netzverwaltung UI
- [ ] Asset CRUD

**Sprint 3 (Wochen 5-6): Authentication**
- [ ] AD-Integration
- [ ] Berechtigungen
- [ ] Asset-Import

---

## 📚 Ressourcen

- [.NET 8 Dokumentation](https://learn.microsoft.com/de-de/dotnet/core/whats-new/dotnet-8)
- [Blazor Server Docs](https://learn.microsoft.com/de-de/aspnet/core/blazor/)
- [MudBlazor Components](https://mudblazor.com/)
- [EF Core Migrations](https://learn.microsoft.com/de-de/ef/core/managing-schemas/migrations/)

---

**Letzte Aktualisierung:** 09.02.2026, 12:00 Uhr  
**Nächster Schritt:** Domain Models vervollständigen
