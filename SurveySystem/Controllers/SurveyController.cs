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
        public async Task<NoContent> AddSurveyAsync(SurveyAddDto newSurvey) {

            await _surveyService.AddSurveyAsync(newSurvey);

            return TypedResults.NoContent();
        }
    }
}
