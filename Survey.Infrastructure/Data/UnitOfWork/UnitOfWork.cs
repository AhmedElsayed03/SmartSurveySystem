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
        public IMemberSurveyRepo MemberSurveyRepo { get; }
        public IMemberRepo MemberRepo { get; }
        public IAdminRepo AdminRepo { get; }
        public ISectionRepo SectionRepo { get; }
        public IUploadedFileRepo UploadedFileRepo { get; }


        public UnitOfWork(SurveyDbContext context,
                          ISurveyRepo surveyRepo,
                          IQuestionRepo questionRepo,
                          IChoiceRepo choiceRepo,
                          ISubmissionRepo submissionRepo,
                          IMemberSurveyRepo memberSurveyRepo,
                          IMemberRepo memberRepo,
                          IAdminRepo adminRepo,
                          ISectionRepo sectionRepo,
                          IUploadedFileRepo uploadedFileRepo)
        {
            _context = context;
            SurveyRepo = surveyRepo;
            QuestionRepo = questionRepo;
            ChoiceRepo = choiceRepo;
            SubmissionRepo = submissionRepo;
            MemberSurveyRepo = memberSurveyRepo;
            MemberRepo = memberRepo;
            AdminRepo = adminRepo;
            SectionRepo = sectionRepo;
            UploadedFileRepo = uploadedFileRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
