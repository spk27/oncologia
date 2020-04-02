using Oncologia.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Oncologia.Application.UnitTests.Common;
using Xunit;
using AutoMapper;
using Oncologia.Application.Pacientes.Queries.GetPacientesList;

namespace Oncologia.Application.UnitTests.Pacientes.Queries
{
    [Collection("QueryCollection")]
    public class GetPacientesListQueryHandlerTest
    { 
        private readonly OncologiaDbContext _context;
        private readonly IMapper _mapper;

        public GetPacientesListQueryHandlerTest(QueryTestFixture fixture)
        {
            _context = fixture.Context;
            _mapper = fixture.Mapper;
        }    

        [Fact]
        public async Task GetPacientesList()
        {
            var sut = new GetPacientesListQuery.GetPacientesListQueryHandler(_context, _mapper);

            var result = await sut.Handle(new GetPacientesListQuery(), CancellationToken.None);

            result.ShouldBeOfType<PacientesListVm>();
            result.Pacientes.Count.ShouldBe(3);
        }
    }
}
