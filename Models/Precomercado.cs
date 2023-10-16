using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoCamadaPersistencia.Models
{
    [Table("Precos")]
    public class Precomercado
    {
        [Key]
        public int id { get; set; }
        [Required]

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name ="Preço")]
        public float preco { get; set; }

        [Required]
        [Display(Name = "Animal")]
        [StringLength(30)]
        public string animal { get; set; }
    }
}
