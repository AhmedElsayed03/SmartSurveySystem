﻿using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Repositories
{
    public interface IChoiceRepo : IGenericRepo<Choice>
    {
        Task<IEnumerable<Choice>> GetAllChoicesAsync(int questionId);
    }
}
