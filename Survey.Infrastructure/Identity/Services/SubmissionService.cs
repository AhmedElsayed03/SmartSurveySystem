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

        public void addSubmission(SubmissionAddDto newSubmission)
        {
            Submission submission = new Submission()
            {
                Text = newSubmission.Text,
                MemberId = newSubmission.MemberId,
                ChoiceId = newSubmission.ChoiceId,
                //QuestionId = newSubmission.QuestionId,
                CreateTime = DateTime.Now,

                //CreatedBy = GetAdminID from Token
            };

            _unitOfWork.SubmissionRepo.AddAsync(submission);
            _unitOfWork.SaveChangesAsync();
        }
    }
}
