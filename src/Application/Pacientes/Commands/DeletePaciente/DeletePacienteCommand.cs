using MediatR;
using Oncologia.Application.Common.Exceptions;
using Oncologia.Application.Common.Interfaces;
using Oncologia.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Oncologia.Application.Pacientes.Commands.DeletePaciente
{
    public class DeletePacienteCommand : IRequest
    {
        public int Id { get; set; }

        public class DeletePacienteCommandHandler : IRequestHandler<DeletePacienteCommand>
        {
            private readonly IOncologiaDbContext _context;

            public DeletePacienteCommandHandler(IOncologiaDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeletePacienteCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Pacientes
                    .FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Paciente), request.Id);
                }

                _context.Pacientes.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
