using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Oncologia.WebUI.Controllers
{
    [Authorize]
    public class PacientesController : BaseController
    {
    }
}
