﻿using Survey.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class QuestionAddDto
    {
        public string Text { get; set; } = string.Empty;
        public int Order { get; set; }
        public int TypeId { get; set; }
        public int SurveyId { get; set; }
    }
}