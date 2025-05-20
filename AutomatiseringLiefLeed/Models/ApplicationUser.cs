using Microsoft.AspNetCore.Identity;

namespace AutomatiseringLiefLeed.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime? DateOfMarriage { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public bool IsSick { get; set; }
        public DateTime? DateOfSickness { get; set; }
    }
}
