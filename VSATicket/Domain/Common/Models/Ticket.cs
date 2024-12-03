using System;
using System.ComponentModel.DataAnnotations;

namespace VSATicket.Domain.Common.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Status { get; set; } = string.Empty;

        public string? Solution { get; set; }
        public string? ResolvedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? OpenedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
    }
}
