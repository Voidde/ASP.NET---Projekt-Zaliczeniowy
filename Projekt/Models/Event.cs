using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    [Table("Events")]
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
        public string? Name { get; set; }
        [Required]
        [Column("EventDescription")]
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        [Column("EventType")]
        [StringLength(30)]
        public string TypeOfEvent { get; set; }
        [Required]
        public DateTime DateOfEvent { get; set; }
        [Required]
        public decimal TicketPrice { get; set; }
        virtual public ISet<Artist> Artists { get; set; }


    }
}
