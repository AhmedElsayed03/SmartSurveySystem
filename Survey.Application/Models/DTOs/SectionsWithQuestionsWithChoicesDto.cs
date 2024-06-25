using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class SectionsWithQuestionsWithChoicesDto
    {
        //Section
        public string SectionName { get; set; } = string.Empty;

        //Question With ChoicesReadDto
        public IEnumerable<QuestionWithChoicesReadDto> Questions = new List<QuestionWithChoicesReadDto>();
    }
}
