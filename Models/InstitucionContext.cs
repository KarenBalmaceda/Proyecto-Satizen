using Microsoft.EntityFrameworkCore;


namespace Satizen_Api.Models
{
    public class InstitucionContext : DbContext
    {


        public InstitucionContext(DbContextOptions<InstitucionContext> options)
            : base(options)
        {
        }


        public DbSet<InstitucionModels> Institucion { get; set; }
        public object InstitucionDto { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}


