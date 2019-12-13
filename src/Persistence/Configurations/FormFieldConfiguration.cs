using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oncologia.Domain.Entities;

namespace Oncologia.Persistence.Configurations
{
    public class FormFieldConfiguration : IEntityTypeConfiguration<FormField>
    {
        public void Configure(EntityTypeBuilder<FormField> builder)
        {

            builder.ToTable("FormField", "Oncologia");

            builder.HasKey(p => p.FormFieldId);

            builder.Property(p => p.FormFieldId).HasColumnName("FormFieldID");

            builder.Property(p => p.FormName)
                .IsRequired()
                .HasMaxLength(50);
            
            builder.Property(p => p.KeyField)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.ValueField);

            builder.Property(p => p.Label)
                .HasMaxLength(250);

            builder.Property(p => p.Order);

            builder.Property(p => p.ColumnsSize).HasDefaultValue(12);

            builder.Property(p => p.ControlType)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
