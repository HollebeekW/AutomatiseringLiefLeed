using System;
using System.Collections.Generic;

namespace AutomatiseringLiefLeed.Models
{
    public class Request
    {
        public int Id { get; set; }
        public required string EmployeeName { get; set; }
        public required string EventType { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public bool ManualReviewRequired { get; set; }
        public bool PaymentApproved { get; set; }
        public string Note { get; set; }
        public ICollection<Notes> Notes { get; set; } = new List<Notes>();
    }
}