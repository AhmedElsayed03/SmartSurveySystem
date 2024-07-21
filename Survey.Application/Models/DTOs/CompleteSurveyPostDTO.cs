using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class CompleteSurveyPostDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;

        //Sections with Questions with Choices

        public IEnumerable<SectionWithQuestionswithChoicesAddDto> Sections { get; set; } = new List<SectionWithQuestionswithChoicesAddDto>();
    }
}
