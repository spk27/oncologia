using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Oncologia.Domain.Entities;
using Oncologia.Persistence;

namespace Oncologia.WebUI.IntegrationTests.Common
{
    public class Utilities
    {
        public static StringContent GetRequestContent(object obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }

        public static async Task<T> GetResponseContent<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(stringResponse);

            return result;
        }

        public static void InitializeDbForTests(OncologiaDbContext context)
        {
            var paciente = new Paciente {
                PrimerNombre = "Daniel"
                ,PrimerApellido = "Aguilar"
                ,TipoCedula = "CE"
                , Cedula = "1028999"
            };

            context.Pacientes.Add(paciente);

            context.SaveChanges();
        }
    }
}
