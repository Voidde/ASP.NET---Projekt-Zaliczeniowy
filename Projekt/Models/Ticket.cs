using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        public string? ClientId { get; set; }

        [ForeignKey("EventId")]
        public int? EventId { get; set; }

        public decimal TicketPrice { get; set; }

        public Event Event { get; set; }



    }
}
