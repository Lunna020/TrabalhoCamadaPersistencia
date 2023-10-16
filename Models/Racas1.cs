using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoCamadaPersistencia.Models
{
    [Table("Racas")]
    public class Racas1
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID: ")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo Raça é obrigatório...")]
        [StringLength(30)]
        [Display(Name = "Raça: ")]
        public string Raca { get; set; }
     
    }
}
