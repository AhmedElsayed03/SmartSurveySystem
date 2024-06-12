using Survey.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Services
{
    public interface ISurveyService
    {
        Task AddSurveyAsync(SurveyAddDto newSurvey);
        Task<CompleteSurveyDTO> GetSurveyAsync(int surveyID);
        Task<List<SurveyReadDto>> GetAllSurveysAsync();
        Task<SurveyWithQuestionsDto> GetSurveyWithQuestionsAsync(int surveyID);

    }
}
