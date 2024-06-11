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
        public async Task<NoContent> AddSurveyAsync(QuestionAddDto newQuestion)
        {

            newQuestion.Token = Request.Headers.Authorization!;
            await _questionService.AddQuestionAsync(newQuestion);

            return TypedResults.NoContent();
        }

    }
}
