﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Models.DTOs
{
    public class CompleteSurveyDto
    {
        //Survey
        public string SurveyName { get; set; } = string.Empty;

        //Sections With Questions With ChoicesDto
        public IEnumerable<SectionsWithQuestionsWithChoicesDto> Sections = new List<SectionsWithQuestionsWithChoicesDto>();
    }
}
