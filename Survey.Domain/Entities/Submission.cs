using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class Submission : Entity
    {
        public string Text { get; set; } = string.Empty;


        //Foreign Key
        public int MemberId { get; set; }
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }

        //Nav Properties
        public Member? Member { get; set; }
        public Choice? Choice { get; set; }
        public Question? Question { get; set; }
    }
}
