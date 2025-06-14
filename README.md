[![Build](https://github.com/HollebeekW/AutomatiseringLiefLeed/actions/workflows/build.yml/badge.svg)]
[![Coverage](https://img.shields.io/endpoint?url=https://gist.githubusercontent.com/Erkan21211/789f6f0d224cdca20d69ff9e68e30652/raw/badge.json)](https://github.com/HollebeekW/AutomatiseringLiefLeed/actions/workflows/build.yml)


# Automatisering Lief & Leed Pot

Deze ASP.NET MVC applicatie automatiseert het aanvraagproces, controle en uitbetaling van de "Lief & Leed Pot" binnen gemeente Almere. De applicatie vermindert administratieve lasten en verhoogt de efficiëntie voor zowel medewerkers als de administratie.

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

## Gebruik

- Dien aanvragen eenvoudig digitaal in via het aanvraagportaal.
- Beheer jubilea en ziektegevallen via een duidelijk controle-dashboard.
- Automatische verwerking van betalingen via Mollie-integratie.
- Bekijk overzichtelijke rapportages voor alle transacties en aanvragen.

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



