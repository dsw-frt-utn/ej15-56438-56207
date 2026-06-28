using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Data.Configurations
{
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            builder.ToTable("Specialities");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.Description)
                .HasMaxLength(500);

            builder.HasIndex(s => s.Name)
                .IsUnique();
        }
    }
}
