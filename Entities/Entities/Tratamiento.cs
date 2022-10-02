using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class Tratamiento
    {
        [Key]
        public int IdTratamiento { get; set; }
        public string? Tipo { get; set; }
        public string? Medicamento { get; set; }
        public string? Descripcion { get; set; }
        public int IdUser { get; set; }
        public virtual User? User { get; set; }
    }
}
