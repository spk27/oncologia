using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oncologia.Domain.Entities;

namespace Oncologia.Persistence.Configurations
{
    public class ValidationConfiguration : IEntityTypeConfiguration<Validation>
    {
        public void Configure(EntityTypeBuilder<Validation> builder)
        {

            builder.ToTable("Validation", "Oncologia");

            builder.HasKey(p => p.ValidationId);

            builder.Property(p => p.ValidationId).HasColumnName("ValidationID");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ValidationValue);

            builder.Property(p => p.Regex);
        }
    }
}
