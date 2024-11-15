using Ilumini.Presentation.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        // get all

        // Get by id
        [HttpGet("{id}")]
        public IActionResult GetOptionById([FromRoute] Guid id)
        {
            return Ok(id);
        }

        // Create quesiton
        [HttpPost]
        public IActionResult CreateOption(CreateOptionRequest request)
        {
            return Ok(request);
        }
    }
}
