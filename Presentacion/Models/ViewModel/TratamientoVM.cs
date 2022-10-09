using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models.ViewModel
{
    public class TratamientoVM
    {
        [Key]
        public int IdTratamiento { get; set; }

        [Required(ErrorMessage = "El Tipo es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Tipo")]
        public string? Tipo { get; set; }


        [Required(ErrorMessage = "El Medicamento es obligatorio")]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Medicina")]
        public string? Medicamento { get; set; }

      
        [StringLength(255, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres")]
        [Display(Name = "Descripcion")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El Usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public int IdUser { get; set; }
        public virtual UserVM? User { get; set; }
    }
}
