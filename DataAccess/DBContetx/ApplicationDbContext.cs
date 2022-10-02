using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DBContetx
{
    public partial class ApplicationDbContext: DbContext
    {
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                settings = new AppConfiguration();
                opsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                opsBuilder.UseSqlServer(settings.sqlConnectionString);
                dbOptions = opsBuilder.Options;
            }
            public DbContextOptionsBuilder<ApplicationDbContext> opsBuilder { get; set; }
            public DbContextOptions<ApplicationDbContext> dbOptions { get; set; }
            private AppConfiguration settings { get; set; }
        }
        public static OptionsBuild ops = new OptionsBuild();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Tratamiento> Tratamientos { get; set; } = null!;
         public virtual DbSet<ParameterSystem> ParameterSystems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
