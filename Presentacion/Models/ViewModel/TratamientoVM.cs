using System.ComponentModel.DataAnnotations;

namespace Presentacion.Models.ViewModel
{
    public class TratamientoVM
    {
        [Key]
        public int IdTratamiento { get; set; }
        public string? Tipo { get; set; }
        public string? Medicamento { get; set; }
        public string? Descripcion { get; set; }
        public int IdUser { get; set; }
        public virtual UserVM? User { get; set; }
    }
}
