using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Survey.Application.Abstractions.Repositories
{
    public interface ISurveyRepo : IGenericRepo<Domain.Entities.Survey>
    {
        Task<Domain.Entities.Survey?> GetCompleteSurvey(int id);
        Task<Domain.Entities.Survey?> GetSurveyWithQuestions(int id);
        Task<Domain.Entities.Survey?> GetSurveyWithQuestionsWithChoices(int id);
    }
}
