## Test F-01 – Aanvraag goed- of afkeuren

| Item | Inhoud |
|------|--------|
| **Requirement** | F-01: “HR kan aanvraag goed- of afkeuren.” |
| **Voorwaarde (Given)** | HR-gebruiker is ingelogd en ziet openstaande aanvraag. |
| **Actie (When)** | HR klikt op **Approve**. |
| **Verwacht resultaat (Then)** | - Status = “Approved”.<br>- E-mail naar aanvrager.<br>- Bedrag wordt vrijgegeven. |
| **Randgevallen** | - HR klikt **Reject**: Status = “Rejected”, e-mail naar aanvrager.<br>- Netwerkfout bij e-mail: Status blijft “Approved”, fout gelogd, retry mogelijk. |
| **Omgeving** | Chrome 124, Edge 124; latency 100 ms. |
| **Testdata** | `testdata/approve_valid.json`<br>`testdata/reject_valid.json`<br>`testdata/email_failure.json` |
| **Status** | _Nog niet uitgevoerd_ |

---

## Test F-02 – Aanvraag afkeuren

| Item | Inhoud |
|------|--------|
| **Requirement** | F-01: “HR kan aanvraag goed- of afkeuren.” |
| **Voorwaarde (Given)** | HR-gebruiker is ingelogd en ziet openstaande aanvraag. |
| **Actie (When)** | HR klikt op **Reject**. |
| **Verwacht resultaat (Then)** | - Status = “Rejected”.<br>- E-mail naar aanvrager.<br>- Geen bedrag vrijgegeven. |
| **Randgevallen** | - HR klikt **Approve**.<br>- Netwerkfout bij e-mail. |
| **Omgeving** | Chrome 124, Edge 124; latency 100 ms. |
| **Testdata** | `testdata/reject_valid.json` |
| **Status** | _Nog niet uitgevoerd_ |

---

## Test F-03 – Netwerkfout bij e-mail

| Item | Inhoud |
|------|--------|
| **Requirement** | F-01: “HR kan aanvraag goed- of afkeuren.” |
| **Voorwaarde (Given)** | HR-gebruiker is ingelogd en ziet openstaande aanvraag. |
| **Actie (When)** | HR klikt op **Approve** of **Reject** en e-mail kan niet worden verzonden. |
| **Verwacht resultaat (Then)** | - Status = “Approved” of “Rejected” zoals gekozen.<br>- Foutmelding gelogd.<br>- E-mail wordt later opnieuw geprobeerd. |
| **Randgevallen** | - E-mailserver komt weer online.<br>- Meerdere pogingen mislukken. |
| **Omgeving** | Chrome 124, Edge 124; latency 100 ms. |
| **Testdata** | `testdata/email_failure.json` |
| **Status** | _Nog niet uitgevoerd_ |