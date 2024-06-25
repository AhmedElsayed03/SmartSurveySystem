using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class Survey : Entity
    {
        public string Name { get; set; } = string.Empty;


        //Nav Property
        public IEnumerable<MemberSurvey> MemberSurveys { get; set; } = new List<MemberSurvey>();
        public IEnumerable<Question> Questions { get; set; } = new List<Question>();
        public IEnumerable<Section> Sections { get; set; } = new List<Section>();
    }
}
