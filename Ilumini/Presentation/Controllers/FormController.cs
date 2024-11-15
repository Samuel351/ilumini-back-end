using Ilumini.Presentation.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {

        // Get all

        // Get By Id
        [HttpGet("{id}")]
        public IActionResult GetFormById([FromRoute] Guid id)
        {
            return Ok(id);
        }

        // Create
        [HttpPost]
        public IActionResult CreateForm(CreateFormRequest request)
        {
            return Ok(request);
        }

    }
}
