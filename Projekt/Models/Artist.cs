using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    public class Artist
    {
        public Artist()
        {
            Events = new HashSet<Event>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistId { get; set; }
        [Required]
        [Column("Name")]
        [StringLength(30)]
        public string? Name { get; set; }
        [Required]
        [Column("Surname")]
        [StringLength(30)]
        public string? Surname { get; set; }
        [Required]
        [Column("Nickname")]
        [StringLength(30)]
        public string? Nickname { get; set; }

        public ICollection<Event> Events { get; set; }


    }
}
