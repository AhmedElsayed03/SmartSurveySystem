using Survey.Application.Abstractions.Repositories;
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
    public class SectionService : ISectionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SectionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddSectionAsync(SectionAddDto sectionAddDto)
        {
            var newSection = new Section()
            {
                CreateTime = DateTime.Now,
                Name = sectionAddDto.Name,
                CreatedBy = await _unitOfWork.SurveyRepo.GetUserFormTokenAsync(sectionAddDto.Token)
            };

            await _unitOfWork.SectionRepo.AddAsync(newSection);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
