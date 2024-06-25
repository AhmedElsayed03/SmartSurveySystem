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

        //Create Survey
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

        //Get All surveys (Names)
        public async Task<List<SurveyReadDto>> GetAllSurveysAsync()
        {
            var surveys = await _unitOfWork.SurveyRepo.GetAllAsync();

            var allSurveys = surveys.Select(s => new SurveyReadDto
            {
                SurveyName = s.Name,
            }).ToList();
            return allSurveys;
        }


        //Get Complete Survey with questions and choices
        public async Task<CompleteSurveyDto> GetSurveyAsync(int surveyID)
        {
            var survey = await _unitOfWork.SurveyRepo.GetCompleteSurvey(surveyID);

            var completeSurvey = new CompleteSurveyDto
            {
                SurveyName = survey!.Name,
                Sections = survey.Sections.Select(i => new SectionsWithQuestionsWithChoicesDto
                {
                    SectionName = i.Name,
                    Questions = survey.Questions.Select(i => new QuestionWithChoicesReadDto
                    {
                        QuestionText = i.Text,
                        Order = i.Order,

                        Choices = i.Choices.Select(i => new ChoiceReadDto
                        {
                            Text = i.Text,
                            Order = i.Order,
                            Next_Question_Order = i.Next_Question_Order
                        }).ToList().OrderBy(i => i.Order)
                    }).ToList().OrderBy(i => i.Order)
                }).ToList()
            };
            return completeSurvey;
        }


        //Get Survey with questions and choices
        public async Task<SurveyWithQuestionsWithChoicesDTO> GetSurveyWithQuestionsWithChoicesAsync(int surveyID)
        {
            var survey = await _unitOfWork.SurveyRepo.GetCompleteSurvey(surveyID);

            var completeSurvey = new SurveyWithQuestionsWithChoicesDTO
            {
                SurveyName = survey!.Name,
                Questions = survey.Questions.Select(i => new QuestionWithChoicesReadDto
                {
                    QuestionText = i.Text,
                    Order = i.Order,

                    Choices = i.Choices.Select(i => new ChoiceReadDto
                    {
                        Text = i.Text,
                        Order = i.Order,
                        Next_Question_Order = i.Next_Question_Order
                    }).ToList().OrderBy(i => i.Order)
                }).ToList().OrderBy(i => i.Order)
            };
            return completeSurvey;
        }

        //Get Survey with questions only
        public async Task<SurveyWithQuestionsDto> GetSurveyWithQuestionsAsync(int surveyID)
        {
            var survey = await _unitOfWork.SurveyRepo.GetSurveyWithQuestions(surveyID);

            var completeSurvey = new SurveyWithQuestionsDto
            {
                SurveyName = survey!.Name,
                Questions = survey.Questions.Select(i => new QuestionReadDto
                {
                    QuestionText = i.Text,
                    Order = i.Order,

                }).ToList().OrderBy(i => i.Order)
            };
            return completeSurvey;
        }
    }
}
