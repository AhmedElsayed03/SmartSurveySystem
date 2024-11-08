﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class SubmissionAddDto
    {
        public string Text { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public int MemberId { get; set; }
        public int ChoiceId { get; set; }
        public int QuestionId { get; set; }
    }
}
