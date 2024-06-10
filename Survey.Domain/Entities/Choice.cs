using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class Choice : Entity
    {
        public string Text { get; set; } = string.Empty;
        public int Order { get; set; }
        public int Next_Question_Order { get; set; }


        //Foreign Key
        public int QuestionId { get; set; }

        //Nav Property

        public Question? Question { get; set; }
        public IEnumerable<Submission> Submissions { get; set; } = new List<Submission>();
    }
}
