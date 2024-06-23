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
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpPost("add-section")]
        [Authorize(Policy = "For Admins")]
        public async Task<NoContent> AddSectionAsync(SectionAddDto newSection)
        {

            newSection.Token = Request.Headers.Authorization!;
            await _sectionService.AddSectionAsync(newSection);

            return TypedResults.NoContent();
        }
    }
}
