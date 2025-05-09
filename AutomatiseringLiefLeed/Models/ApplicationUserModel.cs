using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatiseringLiefLeed.Models
{
    public class ApplicationUserModel : IdentityUser
    {
        [Required, ForeignKey("DepartmentModel")]
        public int DepartmentId { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public DateOnly DateOfEmployment { get; set; }

        public DateOnly? DateOfMarriage { get; set; }

        [Required]
        public bool IsSick { get; set; }

        public DateOnly? DateOfSickness { get; set; }
    }
}
