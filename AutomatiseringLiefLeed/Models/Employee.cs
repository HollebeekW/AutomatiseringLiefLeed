using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Medewerker { get; set; }

        [Required]
        public string Roepnaam { get; set; }

        [Required]
        public string Achternaam { get; set; }

        [Required]
        public string EmailWerk { get; set; }

        [Required]
        public DateOnly GeboorteDatum { get; set; }

        [Required]
        public DateOnly AOWDatum { get; set; }

        [Required]
        public DateOnly InDienstIVMDienstJaren { get; set; }
    }
}
