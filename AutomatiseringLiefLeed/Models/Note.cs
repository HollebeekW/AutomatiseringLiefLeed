using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AutomatiseringLiefLeed.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public virtual Application Application { get; set; }

        [Required]
        public string AuthorName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
