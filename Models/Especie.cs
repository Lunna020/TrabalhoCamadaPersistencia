using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoCamadaPersistencia.Models
{
    [Table("Especies")]
    public class Especie
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string descricao { get; set; }

    }
}
