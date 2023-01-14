using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlaceId { get; set; }

        [Required]
        [StringLength(60)]
        [Column("PlaceName")]
        public string? PlaceName { get; set; }
        [Required]
        [Column("City")]
        [StringLength(30)]
        public string? City { get; set; }

        [Required]
        [StringLength(30)]
        [Column("PostalCode")]
        public string? PostalCode { get; set; }

        [Required]
        [StringLength(30)]
        [Column("Address")]
        public string? Address { get; set; }

        [Required]
        [StringLength(30)]
        [Column("AddressNr")]
        public string? AddressNr { get; set; }

        [Required]
        [StringLength(200)]
        [Column("PlaceDescription")]
        public string? PlaceDescription { get; set; }

        public ICollection<Event> Events { get; set; }



    }
}
