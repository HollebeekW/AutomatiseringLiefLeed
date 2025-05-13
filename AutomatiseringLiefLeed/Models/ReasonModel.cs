using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class ReasonModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double MoneyAmount { get; set; }
    }
}
