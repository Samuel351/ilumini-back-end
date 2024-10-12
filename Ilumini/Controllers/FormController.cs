using Ilumini.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController() : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFormRequest request)
        {
            return Ok(request);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFormRequest request)
        {
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            return Ok();
        }
    }
}
