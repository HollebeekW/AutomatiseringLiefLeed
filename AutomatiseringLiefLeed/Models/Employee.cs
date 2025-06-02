using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public int Medewerker { get; set; }

        public string Roepnaam { get; set; }

        public string Achternaam { get; set; }

        public string EmailWerk { get; set; }

        public DateOnly GeboorteDatum { get; set; }

        public DateOnly AOWDatum { get; set; }

        public DateOnly InDienstIVMDienstJaren { get; set; }
    }
}
