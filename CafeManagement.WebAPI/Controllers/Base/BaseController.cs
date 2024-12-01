using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.WebAPI.Controllers.Base
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
