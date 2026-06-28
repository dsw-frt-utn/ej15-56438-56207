using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            modelBuilder.Entity<Speciality>().HasData(
                new Speciality { Id = Guid.NewGuid(), Name = "Cardiología", Description = "Especialidad del corazón" },
                new Speciality { Id = Guid.NewGuid(), Name = "Neurología", Description = "Especialidad del sistema nervioso" },
                new Speciality { Id = Guid.NewGuid(), Name = "Pediatría", Description = "Especialidad de niños" },
                new Speciality { Id = Guid.NewGuid(), Name = "Dermatología", Description = "Especialidad de la piel" },
                new Speciality { Id = Guid.NewGuid(), Name = "Traumatología", Description = "Especialidad de lesiones óseas" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}