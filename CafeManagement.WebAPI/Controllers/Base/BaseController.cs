using Microsoft.AspNetCore.Mvc;

namespace CafeManagement.WebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
    }
}
