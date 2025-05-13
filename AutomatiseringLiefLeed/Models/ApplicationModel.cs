using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatiseringLiefLeed.Models
{
    public class ApplicationModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string SenderId { get; set; }

        [Required]
        public string SenderName { get; set;}

        [Required]
        public string RecipientId { get; set; }

        [Required]
        public string RecipientName { get; set;}

        [Required]
        public virtual ReasonModel Reason { get; set; }
    }
}
