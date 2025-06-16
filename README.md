![Build](https://img.shields.io/badge/build-passing-brightgreen)
![Coverage](https://img.shields.io/badge/coverage-100%25-brightgreen)

# Automatisering Lief & Leed Pot

Deze ASP.NET MVC applicatie automatiseert het aanvraagproces, controle en uitbetaling van de "Lief & Leed Pot" binnen de gemeente Almere. De applicatie vermindert administratieve lasten en verhoogt de efficiëntie voor zowel medewerkers als de administratie.

## Vereisten

- Visual Studio 2022 of hoger
- .NET 8.0 of hoger
- SQL Server

## Installatie

Volg deze stappen om het project lokaal te draaien:

```bash
git https://github.com/HollebeekW/AutomatiseringLiefLeed.git
cd AutomatiseringLiefLeed
```

## Vervolgens:

1. Open de oplossing (`.sln`) in Visual Studio.
2. Herstel NuGet-pakketten (klik rechts op de oplossing en kies "Restore NuGet Packages").
3. Configureer verbindingsreeksen (connection strings) in `appsettings.json`.
4. Bouw de oplossing (Ctrl+Shift+B).
5. Start het project door op F5 te drukken.

## Meegeleverd Account

Er wordt een standaard admin-account meegeleverd. Het e-mailadres en wachtwoord zijn hiervoor espectievelijk `admin@almere.nl` en `Admin123!`.

## Mogelijkheden

- Dien aanvragen eenvoudig digitaal in via het aanvraagportaal.
- Beheer de afgifte's van jubilea en ziektes via een dashboard.
- Aanvragen m.b.t. jubilea worden automatisch gecontroleerd.
- Aanvragen m.b.t. ziektes en overlijden worden beoordeeld via het adminportaal.
<!-- - Automatische verwerking van betalingen via Mollie-integratie. -->
<!-- - Bekijk overzichtelijke rapportages voor alle transacties en aanvragen. -->

## Email test systeem

Op de branch `email-integration` is een emailsysteem geïmplementeerd. In de readme op die branch staat uitgelegd hoe deze opgezet dient te worden.

### Deployment & monitoring

De Web App wordt na elke geslaagde **build-test** pipeline automatisch
uitgerold naar Azure Web Apps via GitHub Actions (zie workflow `deploy-prod`).

* **Auto-scale** is ingesteld op 1→3 instanties bij CPU > 70 %.
* **Application Insights** verzamelt request-latency (p95), error-rate en
  custom metric *HR-overview latency* (≤ 300 ms – NF-01).
* Alerts: p95 > 500 ms of error > 2 % ⟶ Teams-kanaal *#liefleed-alerts*.

## 📋 Acceptatietesten
* [AcceptatieTests.md](docs/test/AcceptatieTests.md)

## Contact

Hans Pieters - [h.pieters@gemeentealmere.nl](mailto:h.pieters@gemeentealmere.nl)



