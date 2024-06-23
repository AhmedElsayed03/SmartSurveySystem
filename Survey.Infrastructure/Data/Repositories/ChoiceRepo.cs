using Microsoft.EntityFrameworkCore;
using Survey.Application.Abstractions.Repositories;
using Survey.Domain.Entities;
using Survey.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.Repositories
{
    public class ChoiceRepo : GenericRepo<Choice>, IChoiceRepo
    {
        private readonly SurveyDbContext _dbContext;

        public ChoiceRepo(SurveyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Choice>> GetAllChoicesAsync(int questionId)
        {
            var choices = await _dbContext.Choices.Where(x => x.QuestionId == questionId)
                                                  .ToListAsync();

            return choices;             
        }
    }
}