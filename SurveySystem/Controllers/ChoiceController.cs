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
    public class ChoiceController : Controller
    {
        private readonly IChoiceService _choiceService;
        public ChoiceController(IChoiceService choiceService)
        {
            _choiceService = choiceService;
        }

        [HttpPost("add-choice")]
        [Authorize(Policy = "For Admins")]
        public async Task<NoContent> AddChoiceAsync(ChoiceAddDto newChoice)
        {

            newChoice.Token = Request.Headers.Authorization!;
            await _choiceService.AddChoiceAsync(newChoice);

            return TypedResults.NoContent();
        }
    }
}
