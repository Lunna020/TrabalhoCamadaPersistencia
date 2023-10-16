using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoCamadaPersistencia.Models
{
    [Table("Especies")]
    public class Especie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID: ")]
        public int id { get; set; }

        [Required(ErrorMessage ="Campo Espécie é obrigatório...")]
        [StringLength(30)]
        [Display(Name ="Especie: ")]
        public string descricao { get; set; }

    }
}
