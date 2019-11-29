using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Oncologia.Application.Common.Interfaces;
using Oncologia.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Oncologia.Application.Common.Behaviours
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        private readonly IOncologiaDbContext _context;

        public RequestLogger(ILogger<TRequest> logger, IOncologiaDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var name = typeof(TRequest).Name;

            _logger.LogInformation("Oncología --> Solicitud: {Name} {@Request}", 
                name, request);

            _context.Auditorias.Add(new Auditoria {
                FechaYHora = DateTime.Now,
                Accion = name,
                EsError = false,
                Mensaje = $"Se ha llamado a la accion con los siguientes parámetros: \n {request.ToString()}"
            });
            
            _context.SaveChangesAsync(cancellationToken);

            return Task.CompletedTask;
        }
    }
}
