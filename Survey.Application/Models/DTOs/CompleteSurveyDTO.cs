using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class CompleteSurveyDTO //Survey Including Questions, Choices
    {
        //Survey
        public string SurveyName { get; set; } = string.Empty;

        //Question
        public IEnumerable<QuestionReadDto> Questions { get; set; } = new List<QuestionReadDto>();



    }
}
