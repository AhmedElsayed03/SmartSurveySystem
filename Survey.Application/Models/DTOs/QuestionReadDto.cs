﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class QuestionReadDto
    {
        public string QuestionText { get; set; } = string.Empty;
        public int Order { get; set; }

    }
}