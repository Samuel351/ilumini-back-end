using Application.Services.Interfaces;
using Domain.Entities;
using Ilumini.DTOs.Request;
using Ilumini.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController(IFormService formService) : ControllerBase
    {
        private readonly IFormService _formService = formService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _formService.GetAllAsync();

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(response.Value!.Select(x => new FormResponse(x)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _formService.GetByIdAsync(id);

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(new FormResponse(response.Value!));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFormRequest request)
        {
            var response = await _formService.CreateAsync(new Form(request.Name, request.Description));

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(new FormResponse(response.Value!));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFormRequest request)
        {
            var response = await _formService.UpdateAsync(new Form(request.Name, request.Description));

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(new FormResponse(response.Value!));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var response = await _formService.DeleteById(id);

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok();
        }
    }
}
