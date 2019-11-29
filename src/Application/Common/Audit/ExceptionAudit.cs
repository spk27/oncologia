
using System;
using System.Threading;
using System.Threading.Tasks;
using Oncologia.Application.Common.Interfaces;
using Oncologia.Domain.Entities;

namespace Oncologia.Application.Common.Audit {
  public static class ExceptionAudit {
    public static Task Send(string accion, string message, IOncologiaDbContext _context, CancellationToken cancellationToken)
    {
        _context.Auditorias.Add(new Auditoria {
            FechaYHora = DateTime.Now,
            Accion = accion,
            EsError = true,
            Mensaje = message
        });
        
        _context.SaveChangesAsync(cancellationToken);

        return Task.CompletedTask;
    }
  }
}