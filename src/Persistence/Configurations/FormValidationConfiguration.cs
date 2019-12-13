using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Oncologia.Domain.Entities;

namespace Oncologia.Persistence.Configurations
{
    public class FormValidationConfiguration : IEntityTypeConfiguration<FormValidation>
    {
        public void Configure(EntityTypeBuilder<FormValidation> builder)
        {

            builder.ToTable("FormValidation", "Oncologia");

            builder.HasKey(fv => new { fv.FormFieldId, fv.ValidationdId });

            builder.Property(fv => fv.FormFieldId).HasColumnName("FormFieldID");

            builder.Property(fv => fv.ValidationdId).HasColumnName("ValidationID");

            builder.HasOne(f => f.FormField)
                .WithMany(fv => fv.FormValidation)
                .HasForeignKey(f => f.FormFieldId)
                .HasConstraintName("FK_FormField_Validations");
            
            builder.HasOne(v => v.Validation)
                .WithMany(fv => fv.FormValidation)
                .HasForeignKey(v => v.ValidationdId)
                .HasConstraintName("FK_Validation_FormFields");
            
        }
    }
}
