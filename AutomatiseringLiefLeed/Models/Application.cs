using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatiseringLiefLeed.Models
{
    public class Application
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; } // FK to Employee

        [ForeignKey("SenderId")]
        public virtual Employee Sender { get; set; } = null!;

        [Required]
        public int RecipientId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfApplication { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public bool IsAccepted { get; set; }

        [Required]
        public int ReasonId { get; set; }

        [ForeignKey("ReasonId")]
        public virtual Reason? Reason { get; set; }

        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
    }
}
