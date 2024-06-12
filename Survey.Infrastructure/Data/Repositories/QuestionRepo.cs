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
    public class QuestionRepo : GenericRepo<Question>, IQuestionRepo
    {
        private readonly SurveyDbContext _dbContext;

        public QuestionRepo(SurveyDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<Question?> GetQuestionWithChoices(int id)
        {
            var question = await _dbContext.Questions
                                         .Include(i => i.Choices)
                                     .Where(i => i.Id == id)
                                     .FirstOrDefaultAsync();

            if (question != null)
            {
                question.Choices = question.Choices.OrderBy(c => c.Order).ToList();
            }

            return question;
        }

        public async Task<int> GetNextQuestionId(int order)
        {
            int questionId = await _dbContext.Questions
                                       .Where(i => i.Order == order)
                                       .Select(i => i.Id)
                                       .FirstOrDefaultAsync();
            return questionId;
        }
    }
}
