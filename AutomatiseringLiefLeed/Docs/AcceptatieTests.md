﻿## AT-01 – HR keurt aanvraag goed

| Item | Inhoud |
|------|--------|
| **Requirement** | F-01: “HR kan aanvraag goed- of afkeuren.” |
| **Voorwaarde (Given)** | HR-gebruiker is ingelogd en ziet openstaande aanvraag A-123. |
| **Actie (When)** | HR klikt op **Approve**. |
| **Verwacht resultaat (Then)** | - `IsAccepted = true` in DB <br>- Bevestigings-e-mail verzonden naar aanvrager |
| **Randgevallen** | Netwerkfout → foutmelding, aanvraag blijft open. |
| **Omgeving** | Chrome 124, Edge 124; latency 100 ms; InMemory-DB seeded via `TestSeed.cs`. |
| **Automatische run** | xUnit test `ApproveRequest_()` (ApprovalsTest.cs, regel 25). |
| **Status** | Geslaagd op 2024-06-14. |

## AT-02 – HR keurt aanvraag afgekeurd

| Item | Inhoud |
|------|--------|
| **Requirement** | F-01: “HR kan aanvraag goed- of afkeuren.” |
| **Voorwaarde (Given)** | HR-gebruiker is ingelogd en ziet openstaande aanvraag A-123. |
| **Actie (When)** | HR klikt op **Approve**. |
| **Verwacht resultaat (Then)** | - `IsAccepted = true` in DB <br>- Bevestigings-e-mail verzonden naar aanvrager |
| **Randgevallen** | Netwerkfout → foutmelding, aanvraag blijft open. |
| **Automatische run** | xUnit test `RejectRequest_()` (ApprovalsTest.cs, regel 25). |
| **Status** | Geslaagd op 2024-06-14. |

## AT-02 – HR keurt aanvraag afgekeurd

| Item | Inhoud |
|------|--------|
| **Requirement** | F-01: “HR kan aanvraag goed- of afkeuren.” |
| **Voorwaarde (Given)** | HR-gebruiker is ingelogd en ziet openstaande aanvraag A-123. |
| **Actie (When)** | HR klikt op **Approve**. |
| **Verwacht resultaat (Then)** | - `IsAccepted = true` in DB <br>- Bevestigings-e-mail verzonden naar aanvrager |
| **Randgevallen** | Netwerkfout → foutmelding, aanvraag blijft open. |
| **Automatische run** | xUnit test `RejectRequest_()` (ApprovalsTest.cs, regel 25). |
| **Status** | Geslaagd op 2024-06-14. |

## AT-03 – Aanvraag indienen
| Item | Inhoud |
|------|--------|
| **Requirement** | F-02: “Gebruiker kan een aanvraag indienen.” |
| **Voorwaarde (Given)** | Gebruiker is ingelogd en ziet formulier voor nieuwe aanvraag. |
| **Actie (When)** | Gebruiker vult formulier in en klikt op **Indienen**. |

## AT-05 - HR-overzicht levert ≤ 300 ms bij 50 aanvragen
| Item | Inhoud |
|------|--------|
| **Requirement** | F-03: “HR kan een overzicht van aanvragen bekijken.” |
| **Voorwaarde (Given)** | HR-gebruiker is ingelogd en heeft 50 aanvragen in de database. |
| **Actie (When)** | HR klikt op **Overzicht aanvragen**. |
| **Verwacht resultaat (Then)** | - Overzicht wordt geladen binnen 300 ms <br>- Alle 50 aanvragen zichtbaar |
| **Randgevallen** | Serverfout → foutmelding, geen aanvragen getoond. |
