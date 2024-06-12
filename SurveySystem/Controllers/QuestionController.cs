using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Abstractions.Services;
using Survey.Application.Models.DTOs;
using Survey.Infrastructure.Identity.Services;

namespace SurveySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpPost("add-question")]
        [Authorize(Policy = "For Admins")]
        public async Task<NoContent> AddQuestionAsync(QuestionAddDto newQuestion)
        {

            newQuestion.Token = Request.Headers.Authorization!;
            await _questionService.AddQuestionAsync(newQuestion);

            return TypedResults.NoContent();
        }

        [HttpGet("get-question/{id}")]
        public async Task<QuestionReadDto?> GetQuestionAsync(int id)
        {

            var question = await _questionService.GetQuestionAsync(id);

            return question;
        }


        [HttpGet("get-question-with-choices/{id}")]
        public async Task<QuestionWithChoicesReadDto?> GetQuestionWithChoicesAsync(int id)
        {

            var question = await _questionService.GetQuestionWithChoicesAsync(id);

            return question;
        }


        [HttpGet("get-next-question")]
        public async Task<int?> GetNextQuestionId(int choiceId)
        {

            var question = await _questionService.GetNextQuestionIdAsync(choiceId);

            return question;
        }


    }
}
