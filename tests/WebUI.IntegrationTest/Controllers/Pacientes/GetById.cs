using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oncologia.Application.Pacientes.Queries.GetPacienteDetail;
using Oncologia.WebUI.IntegrationTests.Common;
using Shouldly;
using WebUI;
using Xunit;

namespace Oncologia.WebUI.IntegrationTests.Controllers.Pacientes
{
    public class GetById : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetById(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsPacientesListViewModel()
        {
            var client = _factory.GetClient();

            var validId = 1;

            var response = await client.GetAsync($"/api/Pacientes/Get/{validId}");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<PacienteDetailVm>(response);

            Assert.IsType<PacienteDetailVm>(vm);
            Assert.NotNull(vm);
            vm.Id.ShouldBe(1);
        }
    }
}
