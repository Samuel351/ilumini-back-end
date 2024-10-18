using Application.Services.Interfaces;
using Domain.Entities;
using Ilumini.DTOs.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController(IFormInstanceResponseService formInstanceResponseService) : ControllerBase
    {

        private readonly IFormInstanceResponseService _formInstanceResponseService = formInstanceResponseService;

        [HttpPost]
        public async Task<IActionResult> SubmitResponse([FromBody] SubmitResponseRequest request)
        {
            var response = await _formInstanceResponseService.CreateAsync(new FormInstanceResponse(request.FormInstanceId, request.OptionId, request.RecipientId));
            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok();
        }
    }
}
