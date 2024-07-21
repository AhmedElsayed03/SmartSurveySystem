using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class QuestionWithChoicesAddDto
    {
        //Question
        public string Text { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int Order { get; set; }
        public int TypeId { get; set; }
        public int SurveyId { get; set; }
        public int SectionId { get; set; }

        //Choices
        public IEnumerable<ChoiceAddDto> Choices { get; set; } = new List<ChoiceAddDto>();
    }
}
