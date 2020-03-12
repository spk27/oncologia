using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Oncologia.Application.Pacientes.Queries.GetPacientesList;
using Oncologia.Application.Pacientes.Queries.GetPacienteDetail;
using Oncologia.Application.Pacientes.Commands.UpsertPaciente;
using Oncologia.Application.Pacientes.Commands.DeletePaciente;

namespace Oncologia.WebUI.Controllers
{
    public class PacientesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<PacientesListVm>> GetAll() {
            var vm = await Mediator.Send(new GetPacientesListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PacienteDetailVm>> Get(int id) {
            var vm = await Mediator.Send(new GetPacienteDetailQuery { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[ProducesDefaultResponseType]
        public async Task<ActionResult<int>> Upsert(UpsertPacienteCommand command) {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete (int id) {
            await Mediator.Send(new DeletePacienteCommand { Id = id});

            return NoContent();
        } 

    }
}
