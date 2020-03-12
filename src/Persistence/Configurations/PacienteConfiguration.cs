using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oncologia.Domain.Entities;

namespace Oncologia.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {

            builder.ToTable("Paciente", "Oncologia");

            builder.Property(p => p.PacienteId).HasColumnName("PacienteID");

            builder.Property(p => p.PrimerNombre)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.SegundoNombre).HasMaxLength(50);

            builder.Property(p => p.PrimerApellido)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.SegundoApellido).HasMaxLength(50);

            builder.Property(p => p.Cedula)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(p => p.TipoCedula).HasMaxLength(5);  
        }
    }
}
