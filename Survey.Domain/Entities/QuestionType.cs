using Survey.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class QuestionType
    {
        public int Id { get; set; }
        public QuestionTypeEnum QuestionTypeEnum { get; set; }
        public string QuestionTypeString { get; set; } = string.Empty;

        //Nav Properties
        public IEnumerable<Question> Questions { get; set;} = new List<Question>();
    }
}
