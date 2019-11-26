using Microsoft.EntityFrameworkCore;
using Oncologia.Application.Common.Interfaces;
using Oncologia.Domain.Entities;

namespace Oncologia.Persistence
{
    public class OncologiaDbContext : DbContext, IOncologiaDbContext
    {
        public OncologiaDbContext(DbContextOptions<OncologiaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OncologiaDbContext).Assembly);
        }
    }
}
