using Microsoft.AspNetCore.Mvc;

namespace Wherefore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
