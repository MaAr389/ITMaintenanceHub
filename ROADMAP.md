# Roadmap: IT Maintenance Hub

Entwicklungsplan für das IT-Asset- und Patch-Management-System

---

## Übersicht

Das Projekt ist in **3 Phasen** aufgeteilt, wobei jede Phase einen produktiven Zwischenstand liefert.
Sprint-Dauer: **2 Wochen**

---

## Phase 1: MVP - Asset-Grundlage (Wochen 1-6)

**Ziel:** Kernfunktionalität lauffähig, erste Benutzer können Assets anlegen und verwalten.

### Sprint 1 (Wochen 1-2)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| Projektsetup | ☐ | Hoch | .NET 8 Solution mit Clean Architecture, Git-Repository |
| Datenbank & Identity | ☐ | Hoch | EF Core Migrations, ASP.NET Core Identity Setup |
| Domain Models | ☐ | Hoch | Project, Network, Asset, PatchEntry, ApplicationUser |

**Deliverable:** Lauffähige Solution mit Datenbankstruktur

### Sprint 2 (Wochen 3-4)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| Repository Pattern | ☐ | Mittel | Generic Repository + Unit of Work |
| Projekt-/Netzverwaltung | ☐ | Hoch | CRUD für Projekte und Netze (VLANs) |
| Asset CRUD API | ☐ | Hoch | Controller und Services für Assets |
| Grundlegende UI | ☐ | Hoch | Blazor Layout mit MudBlazor, NavMenu |

**Deliverable:** Assets können angelegt und Projekten/Netzen zugeordnet werden

### Sprint 3 (Wochen 5-6)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| AD-Integration | ☐ | Hoch | Windows Authentication, LDAP-Anbindung |
| Zuständigkeiten | ☐ | Hoch | Benutzer zu Projekten/Netzen zuweisen, Berechtigungsprüfung |
| Asset-Import | ☐ | Mittel | CSV/Excel-Import für Bulk-Anlage |
| Asset-Liste UI | ☐ | Hoch | Tabelle mit Filterung, Sortierung, Detailansicht |

**Phase 1 Deliverable:** Produktiv nutzbar für Asset-Inventarisierung mit Zugriffskontrolle

---

## Phase 2: Patch-Dokumentation (Wochen 7-12)

**Ziel:** Vollständige Wartungsverwaltung mit Patch-Zyklen und Dokumentation

### Sprint 4 (Wochen 7-8)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| Patch-Zyklus-Modell | ☐ | Hoch | PatchCycle Entity, 2-wöchige Intervalle verwalten |
| Patch-Eintrag erstellen | ☐ | Hoch | Formular für Updates (Windows/Linux/Firmware/BIOS) |
| Kalender-Ansicht | ☐ | Mittel | Übersicht der Patch-Days |

**Deliverable:** Erste Patch-Dokumentation möglich

### Sprint 5 (Wochen 9-10)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| Batch-Updates | ☐ | Hoch | Mehrere Assets gleichzeitig für Patch-Zyklus auswählen |
| Kommentarsystem | ☐ | Mittel | Comments an Assets, Threading, @-Erwähnungen |
| Status-Dashboard | ☐ | Hoch | KPIs: Erledigte vs. ausstehende Updates pro Zyklus |

**Deliverable:** Komplette Patch-Day-Verwaltung

### Sprint 6 (Wochen 11-12)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| Patch-Historie | ☐ | Mittel | Timeline-View: Was wurde wann an einem Asset gemacht |
| Basic Logging | ☐ | Mittel | Serilog in Datei/Seq (keine Audit-Logs im MVP) |
| Berichte | ☐ | Niedrig | PDF-Export pro Patch-Zyklus |

**Phase 2 Deliverable:** Vollständiges Patch-Management mit Dokumentation

---

## Phase 3: Erweiterungen & Integration (Wochen 13-18)

**Ziel:** Enterprise-Ready mit Automatisierung und Integration

### Sprint 7 (Wochen 13-14)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| Firmware-Tracking | ☐ | Mittel | Versionsverwaltung, Alerts bei Abweichung |
| E-Mail-Notifications | ☐ | Mittel | SMTP-Integration, Erinnerungen vor Patch-Day |
| Audit-Logging | ☐ | Hoch | Wer hat wann was geändert (Compliance) |

**Deliverable:** Automatische Benachrichtigungen

### Sprint 8 (Wochen 15-16)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| REST API | ☐ | Mittel | Endpunkte für externe Systeme (Swagger/OpenAPI) |
| FortiGate-Integration | ☐ | Niedrig | Auto-Import Netzwerkgeräte via API |
| AD-Gruppen-Sync | ☐ | Niedrig | Automatische Benutzer-Synchronisation |

**Deliverable:** API für Monitoring-Tools

### Sprint 9 (Wochen 17-18)

| Task | Status | Priorität | Beschreibung |
|------|--------|----------|---------------|
| Compliance-Reports | ☐ | Mittel | Excel/PDF-Export filterbare Reports |
| Mobile-Ansicht | ☐ | Niedrig | Responsive Design für Tablets |
| Dokumentation | ☐ | Hoch | Technische Doku, Admin-Handbuch, Benutzer-Handbuch |
| Deployment | ☐ | Hoch | Docker-Container, IIS-Setup, Backup-Strategie |

**Phase 3 Deliverable:** Produktionsreifes System mit Behörden-konformer Dokumentation

---

## Backlog (Zukünftige Erweiterungen)

Diese Features können in späteren Releases nachgelegt werden:

- **Inventar-Erweiterung**: Software-Lizenzen, Hardware-Lebenszyklen
- **Ticket-System-Integration**: Jira/ServiceNow-API
- **SNMP-Monitoring**: Automatische Störungsmeldungen
- **KI-Features**: Vorhersage Wartungsbedarf basierend auf historischen Daten
- **SLA-Tracking**: Reaktionszeiten, Eskalationsregeln

---

## Definition of Done

Eine Task gilt als erledigt, wenn:

- [ ] Code implementiert und funktionstüchtig
- [ ] Unit-Tests geschrieben (wo sinnvoll)
- [ ] Code Review durchgeführt
- [ ] Dokumentation aktualisiert
- [ ] Deployment auf Testumgebung erfolgreich
- [ ] Benutzer-Feedback eingeholt (ab Phase 2)

---

## Technologie-Entscheidungen

| Komponente | Technologie | Begründung |
|------------|-------------|-------------|
| Frontend | Blazor Server + MudBlazor | Ideal für interne Tools, kein JavaScript-Framework nötig |
| Backend | ASP.NET Core 8.0 | Modern, performant, gut dokumentiert |
| Datenbank | SQL Server | Wahrscheinlich bereits vorhanden in Behörde |
| ORM | Entity Framework Core | Standard für .NET, Code-First-Ansatz |
| Auth | ASP.NET Identity + LDAP | Integration mit Active Directory |
| Logging | Serilog | Strukturiertes Logging, Seq-Unterstützung |
| CI/CD | GitHub Actions | Kostenlos, direkt integriert |

---

## Sprint-Planung

**Sprint-Rhythmus:**
- Sprint-Dauer: 2 Wochen
- Sprint-Planning: Montag, Woche 1
- Daily Standup: Täglich 9:00 Uhr (optional bei kleinem Team)
- Sprint Review: Freitag, Woche 2
- Sprint Retrospective: Freitag, Woche 2 (nach Review)

**Nächste Schritte:**
1. Sprint 1 starten: Projektsetup + Domain Models
2. GitHub Projects Board erstellen für Task-Tracking
3. Entwicklungsumgebung aufsetzen (VS 2022, SQL Server)

---

**Letzte Aktualisierung:** 09.02.2026  
**Status:** Phase 1, Sprint 1 - Vorbereitung
