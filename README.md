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

## Contact

Hans Pieters - [h.pieters@gemeentealmere.nl](mailto:h.pieters@gemeentealmere.nl)

Projectlink: [https://github.com/jouw-gebruikersnaam/lief-leed-automatisering](https://github.com/jouw-gebruikersnaam/lief-leed-automatisering)

## Email testing
!!! Deze branch niet mergen met main !!!

Om de email functionaliteit te testen (zelf is er gebruik gemaakt van mailtrap.io):
1. ga naar mailtrap.io en maak een account aan.
2. Ga naar Sandbox -> Inboxes -> Add Inbox.
3. Onder SMTP staan een Username en Password. Ga in het project naar `appsettings.json` -> `"SmtpSettings"` en vul deze Username en Password in, bij respectievelijk `"Username:"` en `"Password:"`.
4. Build het project. Bij het aanmaken van een aanvraag en bij goed- en afkeuring wordt een email verzonden naar de inbox op mailtrap.io (alle emails gaan naar dezelfde inbox, ongeacht email-adres).
