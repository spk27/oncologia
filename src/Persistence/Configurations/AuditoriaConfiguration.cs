using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oncologia.Domain.Entities;

namespace Oncologia.Persistence.Configurations
{
    public class AuditoriaConfiguration : IEntityTypeConfiguration<Auditoria>
    {
        public void Configure(EntityTypeBuilder<Auditoria> builder)
        {

            builder.ToTable("Auditoria", "Oncologia");

            builder.Property(a => a.Id).HasColumnName("ID");

            builder.Property(a => a.FechaYHora).HasColumnType("datetime");

            builder.Property(a => a.Usuario).HasMaxLength(50);

            builder.Property(a => a.Accion).HasMaxLength(255);

            builder.Property(a => a.EsError).HasColumnType("bit");

            builder.Property(a => a.Mensaje);
        }
    }
}
