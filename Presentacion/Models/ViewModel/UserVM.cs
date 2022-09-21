using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models.ViewModel
{
    public class UserVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Nombre")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
        [Display(Name = "Apellido")]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [Display(Name = "Correo")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(11, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 9)]
        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }
    }
}
