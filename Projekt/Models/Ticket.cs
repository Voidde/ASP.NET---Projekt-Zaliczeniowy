﻿using Projekt.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Projekt.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [NotMapped]
        public virtual User User { get; set; }
        [Required]
        public int? EventId { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }

        public virtual Event Event { get; set; }



    }
}
