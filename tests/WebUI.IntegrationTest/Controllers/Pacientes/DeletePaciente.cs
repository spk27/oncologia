using System.Net.Http;
using System.Threading.Tasks;
using Oncologia.Application.Pacientes.Commands.DeletePaciente;
using Oncologia.WebUI.IntegrationTests.Common;
using WebUI;
using Xunit;

namespace Oncologia.WebUI.IntegrationTests.Controllers.Pacientes
{
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenDeletePacienteCommand_ReturnsSuccessStatusCode()
        {
            var client = _factory.GetClient();

            var validId = 1;

            var response = await client.DeleteAsync($"/api/Pacientes/Delete/{validId}");

            response.EnsureSuccessStatusCode();
        }
    }
}
