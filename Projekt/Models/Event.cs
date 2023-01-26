using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{

    public class Event
    {
        public Event()
        {
            Artists = new HashSet<Artist>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [Required]
        [Column("EventName")]
        [StringLength(30)]
        public string? EventName { get; set; }

        [Required]
        [Column("EventDescription")]
        [StringLength(150)]
        public string? Description { get; set; }

        [Required]
        [Column("EventType")]
        [StringLength(30)]
        public string? TypeOfEvent { get; set; }

        [Required]
        [Column("DateOfEvent")]
        public DateTime DateOfEvent { get; set; }

        [Required]
        [Column("TicketPrice")]
        public decimal TicketPrice { get; set; }

        public ICollection<Artist> Artists { get; set; }

        public int PlaceId { get; set; }

        public Place Place { get; set; }


    }
}
