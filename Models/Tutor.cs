using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoCamadaPersistencia.Models
{

    [Table("Tutores")]
    public class Tutor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID: ")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Campo Nome é obrigatório...")]
        [StringLength(40)]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "Campo CPF é obrigatório...")]
        [StringLength(11)]
        [Display(Name ="CPF: ")]
        public string cpf { get; set; }
       

        [Required(ErrorMessage = "Campo Cidade é obrigatório...")]
        [StringLength(30)]
        [Display(Name ="Cidade: ")]
        public string cidade { get; set;}


        [Required(ErrorMessage = "Campo Telefone é obrigatório...")]
        [StringLength(11)]
        [Display(Name = "Telefone: ")]
        public string telefone { get; set;}

        [Required(ErrorMessage = "Campo Estado é obrigatório...")]
        [Display(Name = "Estado: ")]
        [StringLength(3)]

        public string estado { get; set; }
    }
}
