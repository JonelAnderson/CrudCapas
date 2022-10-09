using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DBContetx
{
    public partial class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Tratamiento> Tratamientos { get; set; } = null!;

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
