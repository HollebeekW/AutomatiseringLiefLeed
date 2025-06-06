using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Medewerker { get; set; }

        public string? Roepnaam { get; set; }

        public string? Achternaam { get; set; }

        public string? EmailWerk { get; set; }

        [Required]
        public DateOnly GeboorteDatum { get; set; }

        [Required]
        public DateOnly AOWDatum { get; set; }

        [Required]
        public DateOnly InDienstIVMDienstJaren { get; set; }

        // Navigation property
        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
    }
}
