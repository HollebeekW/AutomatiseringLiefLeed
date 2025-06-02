using AutomatiseringLiefLeed.Services;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }

        [ForeignKey(nameof(SenderId))]
        public Employee Sender { get; set; }

        [Required]
        public int RecipientId { get; set; }

        [ForeignKey(nameof(RecipientId))]
        public Employee Recipient { get; set; }

        [Required]
        public int ReasonId { get; set; }

        [ForeignKey(nameof(ReasonId))]
        public Reason Reason { get; set; }

        [Required]
        public DateOnly DateOfApplication { get; set; }

        [Required]
        public DateOnly DateOfIssue { get; set; }

        public string Note { get; set; }

        public bool IsApproved { get; set; }
    }
}
