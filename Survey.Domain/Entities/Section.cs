﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Domain.Entities
{
    public class Section : Entity
    {
        public string Name { get; set; } = string.Empty;

        public Survey? Survey { get; set; }
        public int SurveyId { get; set; }

        public IEnumerable<Question> Questions { get; set; } = new List<Question>();
    }
}
