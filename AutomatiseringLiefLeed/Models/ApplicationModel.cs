using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatiseringLiefLeed.Models
{
    public class ApplicationModel
    {
        public int Id { get; set; }

        [Required, ForeignKey("ApplicationUserModel")]
        public int SenderId { get; set; } //manual application for now, maybe removed in future for automatic applications

        [Required, ForeignKey("DepartmentModel")]
        public int DepartmentId { get; set; }

        [Required, ForeignKey("ApplicationUserModel")]
        public int RecipientId { get; set; }

        [Required, ForeignKey("ReasonModel")]
        public int ReasonId { get; set; }

        [Required]
        public DateOnly DateOfApplication { get; set; } //filled in automatically, 

        [Required]
        public DateOnly DateOfIssue { get; set; }

        public bool? IsApproved { get; set; } //null when sending application
    }
}
