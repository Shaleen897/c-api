using MagicVilla_API.Modelos;
using MagicVilla_API.Modelos.Dto;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Villa> villas { get; set; }
        public DbSet<Persona> persona { get; set; }
        public DbSet<houseDto> house { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>().HasData(
                new Persona()
                {
                    Id= 1,
                    Name="Giul",
                    lastName="anto",
                    FechaCrecion= DateTime.Now,
                    FechaActualizacion= DateTime.Now,
                }
               

             );
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 5,
                    Name = "Villa Real",
                    Detalle = "Detalle de la Villa....",
                    ImgURL = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 50,
                    Tarifa = 500,
                    Amenidad = "",
                    FechaCrecion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                },
                 new Villa()
                 {
                     Id = 6,
                     Name = "Premium Villa Gi",
                     Detalle = "Detalle de la Villa Gi....",
                     ImgURL = "",
                     Ocupantes = 4,
                     MetrosCuadrados = 40,
                     Tarifa = 150,
                     Amenidad = "",
                     FechaCrecion = DateTime.Now,
                     FechaActualizacion = DateTime.Now,
                 }

             );
        }
    }
}
