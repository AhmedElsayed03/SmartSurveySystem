using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Repositories
{
    public interface IQuestionRepo : IGenericRepo<Question>
    {
        Task<Question?> GetQuestionWithChoices(int id);
        Task<int> GetNextQuestionId(int questionId, int nextQuestionOrder);
    }
}
