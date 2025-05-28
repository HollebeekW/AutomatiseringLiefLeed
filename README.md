# Automatisering Lief & Leed Pot

Deze ASP.NET MVC applicatie automatiseert het aanvraagproces, controle en uitbetaling van de "Lief & Leed Pot" binnen gemeente Almere. De applicatie vermindert administratieve lasten en verhoogt de efficiëntie voor zowel medewerkers als de administratie.

## Kenmerken

- Digitaal aanvraagportaal voor medewerkers
- Geautomatiseerde controles voor leeftijds- en dienstjubilea
- Dashboard voor handmatige controle bij ziektegevallen
- Automatische betalingsintegratie met Mollie
- Rapportagemodule voor inzicht in uitbetalingen en aanvragen

## Vereisten

- Visual Studio 2022 of hoger
- .NET 6.0 of hoger
- SQL Server

## Installatie

Volg deze stappen om het project lokaal te draaien:

```bash
git https://github.com/HollebeekW/AutomatiseringLiefLeed.git
cd AutomatiseringLiefLeed
```

Vervolgens:

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

## Bijdragen

Bijdragen zijn welkom! Maak eerst een issue aan om grote veranderingen te bespreken.

1. Fork het project
2. Maak je feature branch (`git checkout -b feature/nieuwe-feature`)
3. Commit je wijzigingen (`git commit -m 'Nieuwe feature toegevoegd'`)
4. Push naar je feature branch (`git push origin feature/nieuwe-feature`)
5. Maak een Pull Request

## Licentie

Dit project is gelicenseerd onder de MIT Licentie.

## Contact

Hans Pieters - [h.pieters@gemeentealmere.nl](mailto:h.pieters@gemeentealmere.nl)

Projectlink: [https://github.com/jouw-gebruikersnaam/lief-leed-automatisering](https://github.com/jouw-gebruikersnaam/lief-leed-automatisering)
