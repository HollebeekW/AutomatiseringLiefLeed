using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class Reason
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double EventPrice { get; set; }

        [Required]
        public bool IsAnniversary { get; set; } //to make automatic date checks easier

        [Required]
        public virtual ICollection<Application> Applications { get; set; }
    }
}
