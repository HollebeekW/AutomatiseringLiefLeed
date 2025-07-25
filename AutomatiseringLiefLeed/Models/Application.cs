﻿using AutomatiseringLiefLeed.Models;
using AutomatiseringLiefLeed.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutomatiseringLiefLeed.Models
{
    public class Application
    {
        public int Id { get; set; }

        [Required]
        public int SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual Employee? Sender { get; set; } = null!;

        [Required]
        public int? RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public virtual Employee? Recipient { get; set; } = null!;

        [Required]
        public int? ReasonId { get; set; }

        [ForeignKey("ReasonId")]
        public virtual Reason? Reason { get; set; }

        public virtual ICollection<Note> Notes { get; set; } = new List<Note>();

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfIssue { get; set; }

        public DateTime? DateOfApplication { get; set; }

        public bool? IsAccepted { get; set; }
    }
}
