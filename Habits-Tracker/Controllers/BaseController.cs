using Habits_Tracker.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Habits_Tracker.Controllers
{
    public class BaseController : ControllerBase
    {
        public IActionResult Result<T>(ResultDto<T> result)
        {
            if(result.StatusCode == HttpStatusCode.NotFound)
                return NotFound(result);
            if (result.StatusCode == HttpStatusCode.BadRequest)
                return BadRequest(result);

            if (result.StatusCode == HttpStatusCode.Unauthorized)
                return Unauthorized(result);

            return Ok(result);
        }
    }
}
