﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class SurveyAddDto
    {
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
