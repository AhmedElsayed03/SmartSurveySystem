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
    public class SubmissionController : Controller
    {
        private readonly ISubmissionService _submissionService;
        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpPost("add-submission")]
        [Authorize(Policy = "For Members")]
        public async Task<NoContent> AddSubmissionAsync(SubmissionAddDto newSubmission)
        {

            newSubmission.Token = Request.Headers.Authorization!;
            await _submissionService.AddSubmissionAsync(newSubmission);

            return TypedResults.NoContent();
        }
    }
}
