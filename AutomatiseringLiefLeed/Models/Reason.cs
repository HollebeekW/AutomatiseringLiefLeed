using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class Reason
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        
        public double? GiftAmount { get; set; }

        public bool? IsAnniversary { get; set; }
        
        public double? AnniversaryYears { get; set; }
    }
}
