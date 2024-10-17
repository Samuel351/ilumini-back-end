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
        public async Task<IActionResult> Create([FromBody] List<CreateQuestionRequest> request)
        {
            var list = request.Select(x => new Question(x.FormId, x.Statement, x.Order, x.IsOpcional, x.LikertType)).ToList();
            var response = await _questionService.CreateBatch(list);

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] List<UpdateQuestionRequest> request)
        {
            var list = request.Select(x => new Question(x.FormId, x.Statement, x.Order, x.IsOpcional, x.LikertType)).ToList();
            var response = await _questionService.UpdateBatch(list);

            if (response.HasError()) return StatusCode((int)response.Error!.ErrorType, response.Error);

            return Ok();
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
