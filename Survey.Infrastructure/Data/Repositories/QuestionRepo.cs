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



        public async Task<int> GetNextQuestionId(int questionId, int nextQuestionOrder) //Getting the parameters from the submitted choices
        {  
            //Get Survey Id using question Id (Gets what is the survey that a certain question belongs to)
            int surveyId = await _dbContext.Surveys
                                       .Where(i => i.Id == questionId)
                                       .Select(i => i.Id)
                                       .FirstOrDefaultAsync();

            //Get Question Order using Question Id then add 1
            if (nextQuestionOrder == 0)
            {
                int Order = await _dbContext.Questions.Where(i => i.Id == questionId)
                           .Select(i => i.Order)
                           .FirstOrDefaultAsync();

                int nextQuestionId = await _dbContext.Questions
                           .Where(i => i.SurveyId == surveyId && i.Order == Order + 1)
                           .Select(i => i.Id)
                           .FirstOrDefaultAsync();

                return nextQuestionId;
            }

            else
            {
                //Get Question Id using Survey Id and Qrder Id
                int nextQuestionId = await _dbContext.Questions
                                           .Where(i => i.SurveyId == surveyId && i.Order == nextQuestionOrder)
                                           .Select(i => i.Id)
                                           .FirstOrDefaultAsync();
                return nextQuestionId;
            }
        }
    }
}
