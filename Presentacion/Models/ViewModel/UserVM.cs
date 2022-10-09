using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models.ViewModel
{
    public class UserVM
    {
        [Key]
        public int IdUser { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres", MinimumLength = 4)]
        [Display(Name = "Nombre")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 8)]
        [Display(Name = "Apellido")]
        public string? LastName { get; set; }

        //[EmailAddress(ErrorMessage = "El campo Correo no es una dirección de correo electrónico válida.")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "El Correo electrónico es incorreto")]
        [Required(ErrorMessage = "El Correo es obligatorio")]
        [StringLength(100, ErrorMessage = "El {0} debe ser maximo {1} caracteres")]
        [Display(Name = "Correo")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(11, ErrorMessage = "El {0} debe ser al menos {2} y maximo {1} caracteres", MinimumLength = 9)]
        [Display(Name = "Teléfono")]
        public string? Phone { get; set; }

        public UserVM()
        {
            Tratamientos = new HashSet<TratamientoVM>();
        }

        //[ForeignKey("Tratamientos")]
        public virtual ICollection<TratamientoVM>? Tratamientos { get; set; }
    }
}
