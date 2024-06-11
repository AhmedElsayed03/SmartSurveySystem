using Survey.Application.Abstractions.Repositories;
using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Application.Models.DTOs;
using Survey.Domain.Entities;
using Survey.Domain.Enum;
using Survey.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Services
{
    public class QuestionService:IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddQuestionAsync(QuestionAddDto newQuestion)
        {
            Question question = new Question()
            {
                Text = newQuestion.Text,
                IsDeleted = false,
                CreateTime = DateTime.Now,
                CreatedBy = await _unitOfWork.SurveyRepo.GetUserFormTokenAsync(newQuestion.Token),
                Order = newQuestion.Order,
                TypeId = newQuestion.TypeId,
                SurveyId = newQuestion.SurveyId,
            };

            await _unitOfWork.QuestionRepo.AddAsync(question);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}