using Oncologia.Application.Pacientes.Queries.GetPacienteDetail;
using Oncologia.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Oncologia.Application.UnitTests.Common;
using Xunit;
using AutoMapper;

namespace Oncologia.Application.UnitTests.Pacientes.Queries
{
    [Collection("QueryCollection")]
    public class GetPacienteDetailQueryHandlerTest
    { 
        private readonly OncologiaDbContext _context;
        private readonly IMapper _mapper;

        public GetPacienteDetailQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }    

        [Fact]
        public async Task GetPacienteDetail()
        {
            var sut = new GetPacienteDetailQuery.GetPacienteDetailQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetPacienteDetailQuery { Id = 1000 }, CancellationToken.None);

            result.ShouldBeOfType<PacienteDetailVm>();
            result.Id.ShouldBe(1000);
        }
    }
}
