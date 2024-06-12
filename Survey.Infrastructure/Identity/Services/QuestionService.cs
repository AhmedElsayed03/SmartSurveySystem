﻿using Survey.Application.Abstractions.Repositories;
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

        //Add new question
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

        //Get Question only
        public async Task<QuestionReadDto?> GetQuestionAsync(int id)
        {
            var question = await _unitOfWork.QuestionRepo.GetByIdAsync(id);
            var questionRead = new QuestionReadDto
            {
                QuestionText = question!.Text,
                Order = question.Order,
            };
            return questionRead;
        }

        //Get question with Choices
        public async Task<QuestionWithChoicesReadDto?> GetQuestionWithChoicesAsync(int id)
        {
            var question = await _unitOfWork.QuestionRepo.GetQuestionWithChoices(id);
            var questionRead = new QuestionWithChoicesReadDto
            {
                QuestionText = question!.Text,
                Order = question.Order,
                Choices = question.Choices.Select(i => new ChoiceReadDto
                {
                    Text=i.Text,
                    Order=i.Order,
                    Next_Question_Order=i.Next_Question_Order
                })
            };
            return questionRead;
        }


        //Get Next question from Choices
        public async Task<int> GetNextQuestionIdAsync(int choiceId)
        {
            var choice = await _unitOfWork.ChoiceRepo.GetByIdAsync(choiceId);


            var nextQuestionOrder = choice!.Next_Question_Order;

            if (nextQuestionOrder == 0 ) //or add null
            {

                var questionId = choice.QuestionId;
                var question = await _unitOfWork.QuestionRepo.GetByIdAsync(questionId);
                var nextQuestion = question!.Order + 1;
                return nextQuestion; //return Id
            }
            else
            {
                var questionId = await _unitOfWork.QuestionRepo.GetNextQuestionId(nextQuestionOrder);
                return questionId; //return Id
            }

        }
    }
}