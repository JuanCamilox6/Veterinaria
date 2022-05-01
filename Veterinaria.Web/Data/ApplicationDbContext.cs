using Microsoft.EntityFrameworkCore;
using Veterinaria.Web.Models;

namespace Veterinaria.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Dueno> duenos { get; set; }
        public DbSet<Mascota> mascotas { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dueno>().HasIndex(t => t.Documento).IsUnique();
            modelBuilder.Entity<Mascota>().HasIndex(k => k.Id).IsUnique();
        }
    

    }
}
