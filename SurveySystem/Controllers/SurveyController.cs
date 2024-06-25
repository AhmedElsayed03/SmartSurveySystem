using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Survey.Application.Abstractions.Services;
using Survey.Application.Models.DTOs;

namespace SurveySystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SurveyController : Controller
    {
        private readonly ISurveyService _surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }


        [HttpPost("create-survey")]
        [Authorize(Policy = "For Admins")]
        public async Task<NoContent> AddSurveyAsync(SurveyAddDto newSurvey)
        {

            newSurvey.Token = Request.Headers.Authorization!;
            await _surveyService.AddSurveyAsync(newSurvey);

            return TypedResults.NoContent();
        }


        [HttpGet("all-surveys")]
        public async Task<List<SurveyReadDto>> GetAllSurveysAsync()
        {
            var surveys = await _surveyService.GetAllSurveysAsync();

            return surveys;
        }

        [HttpGet("get-survey-with-questions/{id}")]
        public async Task<SurveyWithQuestionsDto> GetSurveyWithQuestions(int id)
        {
            var completeSurvey = await _surveyService.GetSurveyWithQuestionsAsync(id);

            return completeSurvey;
        }
        
        [HttpGet("get-survey-with-questions-with-Choices/{id}")]
        public async Task<SurveyWithQuestionsWithChoicesDTO> GetSurveyWithQuestionsWithChoices(int id)
        {
            var completeSurvey = await _surveyService.GetSurveyWithQuestionsWithChoicesAsync(id);

            return completeSurvey;
        }

        [HttpGet("get-survey/{id}")]
        public async Task<CompleteSurveyDto> GetCompleteSurvey(int id)
        {
            var completeSurvey = await _surveyService.GetSurveyAsync(id);

            return completeSurvey;
        }


    }
}
