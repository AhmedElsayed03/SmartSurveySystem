using Microsoft.Extensions.Configuration.UserSecrets;
using Survey.Application.Abstractions.Repositories;
using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SurveyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddSurveyAsync(SurveyAddDto newSurvey)
        {
            Domain.Entities.Survey survey = new Domain.Entities.Survey()
            {

                Name = newSurvey.Name,
                CreateTime = DateTime.Now,
                CreatedBy = await _unitOfWork.SurveyRepo.GetUserFormTokenAsync(newSurvey.Token)

            };

            await _unitOfWork.SurveyRepo.AddAsync(survey);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<SurveyReadDto>> GetAllSurveysAsync()
        {
            var surveys = await _unitOfWork.SurveyRepo.GetAllAsync();

            var allSsurveys = surveys.Select(s => new SurveyReadDto
            {
                SurveyName = s.Name,
            }).ToList();
            return allSsurveys;
        }

        public async Task<CompleteSurveyDTO> GetSurveyAsync(int surveyID)
        {
            var survey = await _unitOfWork.SurveyRepo.GetCompleteSurvey(surveyID);

            var completeSurvey = new CompleteSurveyDTO
            {
                SurveyName = survey!.Name,
                Questions = survey.Questions.Select(i => new QuestionReadDto
                {
                    QuestionText = i.Text,
                    Order = i.Order,

                    Choices = i.Choices.Select(i => new ChoiceReadDto
                    {
                        Text = i.Text,
                        Order = i.Order,
                        Next_Question_Order = i.Next_Question_Order
                    }).ToList()
                }).ToList()
            };
            return completeSurvey;
        }
    }
}
