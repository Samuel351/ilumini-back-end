using Application.Services.Interfaces;
using Domain.Entities;
using Ilumini.DTOs.Request;
using Ilumini.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Ilumini.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController(IQuestionService questionService) : ControllerBase
    {

        private readonly IQuestionService _questionService = questionService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _questionService.GetAllAsync();

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(response.Value!.Select(x => new QuestionResponse(x)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _questionService.GetByIdAsync(id);

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(new QuestionResponse(response.Value!));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestionRequest request)
        {
            var response = await _questionService.CreateAsync(new Question(request.FormId, request.Statement, request.Order, request.IsOpcional, request.LikertType));

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(new QuestionResponse(response.Value!));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateQuestionRequest request)
        {
            var response = await _questionService.CreateAsync(new Question(request.Statement, request.Id, request.FormId, request.Order, request.IsOpcional, request.LikertType));

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok(new QuestionResponse(response.Value!));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var response = await _questionService.DeleteById(id);

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok();
        }
    }
}
