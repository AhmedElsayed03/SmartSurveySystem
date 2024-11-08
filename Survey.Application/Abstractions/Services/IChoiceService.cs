﻿using Survey.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Services
{
    public interface IChoiceService
    {
        Task AddChoiceAsync(ChoiceAddDto newChoice);
        Task<IEnumerable<ChoiceReadDto>> GetAllChoicesAsync(int QuestionId);
    }
}
