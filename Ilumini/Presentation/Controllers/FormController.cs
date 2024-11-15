using Ilumini.Presentation.DTOs.Request;
using Ilumini.Presentation.DTOs.Response;
using Ilumini.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController(IFormService formService) : ControllerBase
    {

        private readonly IFormService _formService = formService;

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

        [HttpPost]
        [Route("{formId}/launch-form")]
        public IActionResult LauchForm([FromRoute] Guid formId)
        {
            var result = _formService.LauchForm(formId);
            if (result.HasResponseModel()) return StatusCode(result.ResponseModel!.StatusCode, result.ResponseModel);
            return Ok(result.Value!);
        }

        [HttpGet]
        [Route("form-instance/{instanceId}")]
        public IActionResult GetFormInstanceId([FromRoute] Guid instanceId)
        {
            var result = _formService.GetFormByInstance(instanceId);
            if (result.HasResponseModel()) return StatusCode(result.ResponseModel!.StatusCode, result.ResponseModel);
            return Ok(result.Value!);
        }

        [HttpPost]
        [Route("save-answers")]
        public IActionResult SaveAnwers(List<FormAnswerRequest> requests)
        {
            var result = _formService.SetResponse(requests);
            return Ok(result);
        }
    }
}
