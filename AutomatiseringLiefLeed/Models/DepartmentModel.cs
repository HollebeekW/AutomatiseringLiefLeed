using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class DepartmentModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
