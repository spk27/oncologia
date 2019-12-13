using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oncologia.Application.Forms.Queries.GetFormDetail;
using System.Threading.Tasks;

namespace Oncologia.WebUI.Controllers
{
    public class FormsController : BaseController
    {
        [HttpGet("{formName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FormListVm>> Get(string formName) {
            var vm = await Mediator.Send(new GetFormDetailQuery { FormName = formName });

            return Ok(vm);
        }
    }
}
