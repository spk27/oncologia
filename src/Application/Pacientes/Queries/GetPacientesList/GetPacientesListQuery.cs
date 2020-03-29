using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oncologia.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Oncologia.Application.Pacientes.Queries.GetPacientesList
{
    public class GetPacientesListQuery : IRequest<PacientesListVm>
    {
        public class GetPacientesListQueryHandler : IRequestHandler<GetPacientesListQuery, PacientesListVm>
        {
            private readonly IOncologiaDbContext _context;
            private readonly IMapper _mapper;

            public GetPacientesListQueryHandler(IOncologiaDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PacientesListVm> Handle(GetPacientesListQuery request, CancellationToken cancellationToken)
            {
                var Pacientes = await _context.Pacientes
                    .ProjectTo<PacienteDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                var vm = new PacientesListVm
                {
                    Pacientes = Pacientes,
                    // Count = Pacientes.Count
                };

                return vm;
            }
        }
    }
}
