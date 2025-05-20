namespace AutomatiseringLiefLeed.Models
{
    public class Notes
    {
        public int Id { get; set; }

        public string AuthorName { get; set; } = string.Empty;

        public string Text { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int RequestId { get; set; }
        public Request Request { get; set; } = null!;
    }

}

