using System.Net.Http;
using System.Threading.Tasks;
using Oncologia.Application.Pacientes.Commands.UpsertPaciente;
using Oncologia.WebUI.IntegrationTests.Common;
using WebUI;
using Xunit;

namespace Oncologia.WebUI.IntegrationTests.Controllers.Pacientes
{
    public class Upsert : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public Upsert(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GivenInsertPacienteCommand_ReturnsSuccessStatusCode()
        {
            var client = _factory.GetClient();

            var command = new UpsertPacienteCommand
            {
                Id = null
                , PrimerNombre = "Daniel"
                , PrimerApellido = "Aguilar"
                , Cedula = "1028999"
                , TipoCedula = "CE"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/Pacientes/Upsert", content);

            response.EnsureSuccessStatusCode();
        }
        
        
        [Fact]
        public async Task GivenEditPacienteCommand_ReturnsSuccessStatusCode()
        {
            var client = _factory.GetClient();

            var command = new UpsertPacienteCommand
            {
                Id = 1
                , PrimerNombre = "Daniel"
                , PrimerApellido = "Aguilar"
                , Cedula = "1028999"
                , TipoCedula = "CE"
            };

            var content = Utilities.GetRequestContent(command);

            var response = await client.PostAsync($"/api/Pacientes/Upsert", content);

            response.EnsureSuccessStatusCode();
        }
    }
}
