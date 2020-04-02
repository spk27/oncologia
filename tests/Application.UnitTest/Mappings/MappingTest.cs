using AutoMapper;
using Oncologia.Application.Pacientes.Queries.GetPacienteDetail;
using Oncologia.Domain.Entities;
using Shouldly;
using Xunit;

namespace Oncologia.Application.UnitTests.Mappings
{
    public class MappingTests : IClassFixture<MappingTestsFixture>
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTests(MappingTestsFixture fixture)
        {
            _configuration = fixture.ConfigurationProvider;
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Fact]
        public void ShouldMapCategoryToPacienteDetailVm()
        {
            var entity = new Paciente();

            var result = _mapper.Map<PacienteDetailVm>(entity);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<PacienteDetailVm>();
        }
    }
}