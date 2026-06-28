using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Dsw2026Ej15.Domain.Entities;

namespace Dsw2026Ej15.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.ToTable("Doctors");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(d => d.LicenseNumber)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.IsActive)
                .IsRequired();

            builder.HasOne(d => d.Speciality)
                .WithMany()
                .HasForeignKey(d => d.SpecialityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(d => d.LicenseNumber)
                .IsUnique();
        }
    }
}
