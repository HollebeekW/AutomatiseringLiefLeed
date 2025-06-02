using AutomatiseringLiefLeed.Data;
using Humanizer;
using AutomatiseringLiefLeed.Models;
using AutomatiseringLiefLeed.Utils;

namespace LiefLeedAutomatisering.Services
{
    public class EmployeeImportService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeImportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ImportFromXmlAsync(string xml)
        {
            var data = XmlHelper.DeserialiseEmployees(xml);
            var existingMedewerkers = new HashSet<int>(_context.Employees.Select(e => e.Medewerker));

            //convert datetime to date only
            DateOnly? ToDateOnly(DateTime? dt) => dt.HasValue ? DateOnly.FromDateTime(dt.Value) : (DateOnly?)null;

            foreach (var item in data.Employees)
            {
                //try to convert string to int
                if (!int.TryParse(item.Medewerker, out int medewerkerNummer))
                    continue;

                //check if to be added employee already exists
                if (existingMedewerkers.Contains(medewerkerNummer))
                    continue;

                var employee = new Employee
                {
                    Medewerker = medewerkerNummer,
                    Roepnaam = item.Roepnaam,
                    Achternaam = item.Achternaam,
                    EmailWerk = item.EmailWerk,
                    GeboorteDatum = ToDateOnly(item.GeboorteDatum) ?? default, //if date is empty, use default value (0001-01-01)
                    AOWDatum = ToDateOnly(item.AOWDatum) ?? default, //see above
                    InDienstIVMDienstJaren = ToDateOnly(item.InDienstIVMDienstJaren) ?? default, //also see above
                };

                _context.Employees.Add(employee);
            }

            await _context.SaveChangesAsync();
        }

    }
}