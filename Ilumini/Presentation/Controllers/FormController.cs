using Ilumini.Presentation.DTOs.Request;
using Ilumini.Services.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController(IFormService formService) : ControllerBase
    {

        private readonly IFormService _formService = formService;

        // Get all

        // Get By Id
        [HttpGet("{id}")]
        public IActionResult GetFormById([FromRoute] Guid id)
        {
            var result = _formService.GetFormById(id);
            if (result.HasResponseModel()) return StatusCode(result.ResponseModel!.StatusCode, result.ResponseModel);
            return Ok(result.Value!);
        }

        // Create
        [HttpPost]
        public IActionResult CreateForm(CreateFormRequest request)
        {
            var result = _formService.CreateForm(request);
            return StatusCode(result.ResponseModel!.StatusCode, result.ResponseModel);
        }

    }
}
