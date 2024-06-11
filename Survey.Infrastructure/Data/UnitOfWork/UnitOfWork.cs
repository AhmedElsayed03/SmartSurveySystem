using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Survey.Application.Abstractions.Repositories;
using Survey.Application.Abstractions.UnitOfWork;
using Survey.Infrastructure.Data.Context;

namespace Survey.Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        public ISurveyRepo SurveyRepo { get; }
        public IQuestionRepo QuestionRepo { get; }private readonly SurveyDbContext _context;
        public IChoiceRepo ChoiceRepo { get; }
        public ISubmissionRepo SubmissionRepo { get; }
        public IFileUploadRepo FileUploadRepo { get; }
        public IMemberSurveyRepo MemberSurveyRepo { get; }
        public IMemberRepo MemberRepo { get; }
        public IAdminRepo AdminRepo { get; }
        public UnitOfWork(SurveyDbContext context,
                          ISurveyRepo surveyRepo,
                          IQuestionRepo questionRepo,
                          IChoiceRepo choiceRepo,
                          ISubmissionRepo submissionRepo,
                          IFileUploadRepo fileUploadRepo,
                          IMemberSurveyRepo memberSurveyRepo,
                          IMemberRepo memberRepo,
                          IAdminRepo adminRepo)
        {
            _context = context;
            SurveyRepo = surveyRepo;
            QuestionRepo = questionRepo;
            ChoiceRepo = choiceRepo;
            SubmissionRepo = submissionRepo;
            FileUploadRepo = fileUploadRepo;
            MemberSurveyRepo = memberSurveyRepo;
            MemberRepo = memberRepo;
            AdminRepo = adminRepo;

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
