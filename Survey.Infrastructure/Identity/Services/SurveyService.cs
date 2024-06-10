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
    public class SurveyService:ISurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SurveyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void addSurvey(SurveyAddDto newSurvey)
        {
            Domain.Entities.Survey survey = new Domain.Entities.Survey() {

                Name = newSurvey.Name,
                CreateTime = DateTime.Now,
                //CreatedBy = GetAdminID from Token

            };

            _unitOfWork.SurveyRepo.AddAsync(survey);
            _unitOfWork.SaveChangesAsync();
        }
    }
}
