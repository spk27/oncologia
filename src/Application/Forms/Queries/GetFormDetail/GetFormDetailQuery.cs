using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Oncologia.Application.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Oncologia.Application.Common.Exceptions;
using Oncologia.Domain.Entities;
using System.Linq;

namespace Oncologia.Application.Forms.Queries.GetFormDetail {
    public class GetFormDetailQuery : IRequest<FormListVm> {
        
        public string FormName { get; set; }

        public class GetFormDetailQueryHandler : IRequestHandler<GetFormDetailQuery, FormListVm> {
            private readonly IOncologiaDbContext _context;

            private readonly IMapper _mapper;

            public GetFormDetailQueryHandler(IOncologiaDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FormListVm> Handle(GetFormDetailQuery request, CancellationToken cancellationToken) {
                
                var Formulario = await _context.FormFields
                    .Include(f => f.FormValidation)
                        .ThenInclude(v => v.Validation)
                    .Where(f => f.FormName == request.FormName)
                    .Select(f => FormDetailVm.Create(f))
                    // .ProjectTo<FormDetailVm>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (Formulario == null || Formulario.Count == 0) throw new NotFoundException(nameof(FormField), request.FormName);

                var vm = new FormListVm
                {
                    Formulario = Formulario,
                    Count = Formulario.Count
                };

                return vm;
            }
        }
    }
}