using System;
using Microsoft.EntityFrameworkCore;
using Oncologia.Domain.Entities;
using Oncologia.Persistence;

namespace Oncologia.Application.UnitTests.Common
{
    public class OncologiaContextFactory
    {
        public static OncologiaDbContext Create()
        {
            var options = new DbContextOptionsBuilder<OncologiaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new OncologiaDbContext(options);

            context.Database.EnsureCreated();

            context.Pacientes.AddRange(new[] {
                new Paciente { PacienteId = 1000, PrimerNombre = "Adam", PrimerApellido="Cogan" },
                new Paciente { PacienteId = 1001, PrimerNombre = "Jason", PrimerApellido="Taylor" },
                new Paciente { PacienteId = 1002, PrimerNombre = "Brendan", PrimerApellido="Richards" },
            });

            context.SaveChanges();

            return context;
        }

        public static void Destroy(OncologiaDbContext context)
        {
            context.Database.EnsureDeleted();

            context.Dispose();
        }
    }
}