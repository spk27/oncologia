using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Oncologia.Application.Common.Exceptions;
using Oncologia.Application.Common.Interfaces;
using Oncologia.Domain.Entities;

namespace Oncologia.Application.Pacientes.Commands.UpsertPaciente
{
    public class UpsertPacienteCommand : IRequest<int>
    {
        public int? Id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Cedula { get; set; }
        public string TipoCedula { get; set; }

        public class UpsertPacienteCommandHandler : IRequestHandler<UpsertPacienteCommand, int>
        {
            private readonly IOncologiaDbContext _context;

            public UpsertPacienteCommandHandler(IOncologiaDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpsertPacienteCommand request, CancellationToken cancellationToken)
            {
                Paciente entity;

                if (request.Id.HasValue)
                {
                    entity = await _context.Pacientes.FindAsync(request.Id.Value);

                    if (entity == null) {
                        throw new NotFoundException(nameof(Paciente), request.Id, _context, cancellationToken);
                    }
                }
                else
                {
                    entity = new Paciente();

                    _context.Pacientes.Add(entity);
                }

                entity.PrimerNombre = request.PrimerNombre;
                entity.SegundoNombre = request.SegundoNombre;
                entity.PrimerApellido = request.PrimerApellido;
                entity.SegundoApellido = request.SegundoApellido;
                entity.Cedula = request.Cedula;
                entity.TipoCedula = request.TipoCedula;

                await _context.SaveChangesAsync(cancellationToken);

                return entity.PacienteId;
            }
        }
    }
}
