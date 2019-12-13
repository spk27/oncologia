using Microsoft.EntityFrameworkCore;
using Oncologia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Oncologia.Application.Common.Interfaces
{
    public interface IOncologiaDbContext
    {
        DbSet<Paciente> Pacientes { get; set; }
        DbSet<Auditoria> Auditorias { get; set; }
        DbSet<FormField> FormFields { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
