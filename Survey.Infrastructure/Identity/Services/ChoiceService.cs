﻿using Survey.Application.Abstractions.Repositories;
using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Application.Models.DTOs;
using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Services
{   
    public class ChoiceService:IChoiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChoiceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddChoiceAsync(ChoiceAddDto newChoice)
        {
            Choice Choice = new Choice()
            {
                Text = newChoice.Text,
                Order = newChoice.Order,
                QuestionId = newChoice.QuestionId,
                Next_Question_Order = newChoice.Next_Question_Order, //Nullable
                CreateTime = DateTime.Now,
                CreatedBy = await _unitOfWork.SurveyRepo.GetUserFormTokenAsync(newChoice.Token)
            };

            await _unitOfWork.ChoiceRepo.AddAsync(Choice);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChoiceReadDto>> GetAllChoicesAsync(int QuestionId)
        {
            var choices = await _unitOfWork.ChoiceRepo.GetAllChoicesAsync(QuestionId);

            var readChoices = choices.Select(x => new ChoiceReadDto()
            {

                Text = x.Text,
                Next_Question_Order = x.Next_Question_Order,
                Order = x.Order
            }).ToList();

            return readChoices;
        }
        
    }
}