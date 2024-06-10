using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class MemberSurvey
    {
        public int MemberId { get; set; }
        public int SurveyId { get; set; }
        public Member Member { get; set; } = null!;
        public Survey Survey { get; set; } = null!;
    }
}
