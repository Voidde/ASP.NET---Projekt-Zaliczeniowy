using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Projekt.Models
{
    [DataContract]
    public class Event
    {
        
        public Event()
        {
            Artists = new HashSet<Artist>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int EventId { get; set; }

        [DataMember]
        [Required]
        [Column("EventName")]
        [StringLength(30)]
        public string? EventName { get; set; }

        [DataMember]
        [Required]
        [Column("EventDescription")]
        [StringLength(150)]
        public string? Description { get; set; }

        [DataMember]
        [Required]
        [Column("EventType")]
        [StringLength(30)]
        public string? TypeOfEvent { get; set; }

        [DataMember]
        [Required]
        [Column("DateOfEvent")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfEvent { get; set; }

        [DataMember]
        [Required]
        [Column("TicketPrice")]
        public decimal TicketPrice { get; set; }

        [DataMember]
        public int PlaceId { get; set; }
        public virtual Place? Place { get; set; }

        public ICollection<Artist> Artists { get; set; }



    }
}
