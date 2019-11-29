using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oncologia.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Oncologia.Application.Common.Exceptions;
using Oncologia.Domain.Entities;

namespace Oncologia.Application.Pacientes.Queries.GetPacienteDetail {
    public class GetPacienteDetailQuery : IRequest<PacienteDetailVm> {
        
        public int Id { get; set; }

        public class GetPacienteDetailQueryHandler : IRequestHandler<GetPacienteDetailQuery, PacienteDetailVm> {
            private readonly IOncologiaDbContext _context;

            private readonly IMapper _mapper;

            public GetPacienteDetailQueryHandler(IOncologiaDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PacienteDetailVm> Handle(GetPacienteDetailQuery request, CancellationToken cancellationToken) {
                var entity = await _context.Pacientes.FindAsync(request.Id);

                if (entity == null) {
                    throw new NotFoundException(nameof(Paciente), request.Id, _context, cancellationToken);
                }

                return _mapper.Map<PacienteDetailVm>(entity);
            }
        }
    }
}