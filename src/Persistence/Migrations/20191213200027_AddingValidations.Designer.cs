﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oncologia.Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(OncologiaDbContext))]
    [Migration("20191213200027_AddingValidations")]
    partial class AddingValidations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Oncologia.Domain.Entities.Auditoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Accion")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("EsError")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaYHora")
                        .HasColumnType("datetime");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Auditoria","Oncologia");
                });

            modelBuilder.Entity("Oncologia.Domain.Entities.FormField", b =>
                {
                    b.Property<int>("FormFieldId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("FormFieldID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ColumnsSize")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.Property<string>("ControlType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("KeyField")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<string>("ValueField")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FormFieldId");

                    b.ToTable("FormField","Oncologia");
                });

            modelBuilder.Entity("Oncologia.Domain.Entities.FormValidation", b =>
                {
                    b.Property<int>("FormFieldId")
                        .HasColumnName("FormFieldID")
                        .HasColumnType("int");

                    b.Property<int>("ValidationdId")
                        .HasColumnName("ValidationID")
                        .HasColumnType("int");

                    b.HasKey("FormFieldId", "ValidationdId");

                    b.HasIndex("ValidationdId");

                    b.ToTable("FormValidation","Oncologia");
                });

            modelBuilder.Entity("Oncologia.Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("PacienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PacienteID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PrimerNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SegundoApellido")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("SegundoNombre")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TipoCedula")
                        .IsRequired()
                        .HasColumnType("char(2)");

                    b.HasKey("PacienteId");

                    b.ToTable("Paciente","Oncologia");
                });

            modelBuilder.Entity("Oncologia.Domain.Entities.Validation", b =>
                {
                    b.Property<int>("ValidationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ValidationID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Regex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ValidationValue")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ValidationId");

                    b.ToTable("Validation","Oncologia");
                });

            modelBuilder.Entity("Oncologia.Domain.Entities.FormValidation", b =>
                {
                    b.HasOne("Oncologia.Domain.Entities.FormField", "FormField")
                        .WithMany("FormValidation")
                        .HasForeignKey("FormFieldId")
                        .HasConstraintName("FK_FormField_Validations")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Oncologia.Domain.Entities.Validation", "Validation")
                        .WithMany("FormValidation")
                        .HasForeignKey("ValidationdId")
                        .HasConstraintName("FK_Validation_FormFields")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
