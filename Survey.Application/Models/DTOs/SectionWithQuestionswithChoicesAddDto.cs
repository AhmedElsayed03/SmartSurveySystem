using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class SectionWithQuestionswithChoicesAddDto
    {
        //Section
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;


        //Questions with Choices
        public IEnumerable<QuestionWithChoicesAddDto> Questions { get; set; } = new List<QuestionWithChoicesAddDto>();
    }
}
