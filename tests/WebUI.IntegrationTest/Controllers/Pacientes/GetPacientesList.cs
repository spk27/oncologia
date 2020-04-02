using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Oncologia.Application.Pacientes.Queries.GetPacientesList;
using Oncologia.WebUI.IntegrationTests.Common;
using WebUI;
using Xunit;

namespace Oncologia.WebUI.IntegrationTests.Controllers.Pacientes
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnsPacientesListViewModel()
        {
            var client = _factory.GetClient();

            var response = await client.GetAsync($"/api/Pacientes/GetAll");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<IList<PacienteDto>>(response);

            Assert.IsType<List<PacienteDto>>(vm);
            Assert.NotEmpty(vm);
        }
    }
}
