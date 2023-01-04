using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekt.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [Column("Name")]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [Column("Surname")]
        [StringLength(30)]
        public string Surname { get; set; }
    }
}
