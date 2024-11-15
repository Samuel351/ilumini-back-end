using Ilumini.Presentation.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        // get all

        // Get by id
        [HttpGet("{id}")]
        public IActionResult GetQuestionById([FromRoute] Guid id)
        {
            return Ok(id);
        }

        // Create quesiton
        [HttpPost]
        public IActionResult CreateQuestion(CreateQuestionRequest request)
        {
            return Ok(request);
        }

    }
}
