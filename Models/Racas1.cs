using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoCamadaPersistencia.Models
{
    [Table("Racas")]
    public class Racas1
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Raca { get; set; }
    }
}
