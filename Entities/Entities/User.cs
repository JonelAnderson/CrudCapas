using System.ComponentModel.DataAnnotations;

namespace Entities.Entities
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
     
        public string? Name { get; set; }

        public string? LastName { get; set; }

      
        public string? Email { get; set; }

        public string? Phone { get; set; }

        public User()
        {
            Tratamientos = new HashSet<Tratamiento>();
        }
        public virtual ICollection<Tratamiento>? Tratamientos { get; set; }
    }
}
