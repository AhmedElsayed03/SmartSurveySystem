using Survey.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class Question : Entity
    {
        public string Text { get; set; } = string.Empty;
        public int Order { get; set; }
        public bool IsDeleted { get; set; }

        //Foreign Key
        public int SurveyId { get; set; }
        public int QTypeId { get; set; }
        public int SectionId { get; set; }

        //Nav Property
        public Survey? Survey { get; set; }
        public QuestionType? QType { get; set; }
        public Section? Section { get; set; }
        public IEnumerable<Choice> Choices { get; set; } = new List<Choice>();
        public IEnumerable<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
