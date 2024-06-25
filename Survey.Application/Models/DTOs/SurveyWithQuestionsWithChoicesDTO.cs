using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class SurveyWithQuestionsWithChoicesDTO //Survey Including Questions, Choices
    {
        //Survey
        public string SurveyName { get; set; } = string.Empty;

        //Question
        public IEnumerable<QuestionWithChoicesReadDto> Questions { get; set; } = new List<QuestionWithChoicesReadDto>();



    }
}
