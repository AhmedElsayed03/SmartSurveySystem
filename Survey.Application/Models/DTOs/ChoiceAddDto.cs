using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class ChoiceAddDto
    {
        public string Text { get; set; } = string.Empty;
        public int Order { get; set; }
        public int Next_Question_Order { get; set; }
        public int QuestionId { get; set; }

    }
}
