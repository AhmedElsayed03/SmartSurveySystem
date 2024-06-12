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
    public class SubmissionService : ISubmissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SubmissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddSubmissionAsync(SubmissionAddDto newSubmission)
        {
            Submission submission = new Submission()
            {
                Text = newSubmission.Text,
                MemberId = newSubmission.MemberId,
                ChoiceId = newSubmission.ChoiceId,
                CreateTime = DateTime.Now,
                CreatedBy = await _unitOfWork.SurveyRepo.GetUserFormTokenAsync(newSubmission.Token)
                //QuestionId = newSubmission.QuestionId,
            };

            await _unitOfWork.SubmissionRepo.AddAsync(submission);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
