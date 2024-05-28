using Microsoft.EntityFrameworkCore;
using Satizen_Api.Models;

namespace Satizen_Api.Datos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<InstitucionModels> Institucion { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InstitucionModels>().HasData(
                new InstitucionModels()
                {
                    idInstitucion = 1,
                    nombreInstitucion = "Santa Clare",
                    direccionInstitucion = "calle pepe",
                    telefonoInstitucion = "5467389",
                    correoInstitucion = "santaclare@gmail.com",
                    celularInstitucion = "26347859"
                },
                new InstitucionModels()
                {
                    idInstitucion = 2,
                    nombreInstitucion = "Santa Clara",
                    direccionInstitucion = "calle pepi",
                    telefonoInstitucion = "54673897",
                    correoInstitucion = "santaclara@gmail.com",
                    celularInstitucion = "2634785967"
                }
               );


    }   }
}
