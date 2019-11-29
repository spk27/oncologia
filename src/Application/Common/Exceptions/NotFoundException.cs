using System;
using System.Threading;
using Oncologia.Application.Common.Audit;
using Oncologia.Application.Common.Interfaces;

namespace Oncologia.Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key, IOncologiaDbContext context, CancellationToken cancellationToken)
            : base($"Entidad '{name}' ({key}) no fue encontrada.")
        {
            ExceptionAudit.Send("", $"Entidad '{name}' ({key}) no fue encontrada.", context, cancellationToken);
        }
    }
}