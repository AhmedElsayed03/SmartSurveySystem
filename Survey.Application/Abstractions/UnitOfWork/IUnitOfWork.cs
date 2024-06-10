﻿using Survey.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ISurveyRepo SurveyRepo { get; }
        public IQuestionRepo QuestionRepo { get; }
        public IChoiceRepo ChoiceRepo { get; }
        public ISubmissionRepo SubmissionRepo { get; }
        public IFileUploadRepo FileUploadRepo { get; }
        public IMemberSurveyRepo MemberSurveyRepo { get; }
        public IMemberRepo MemberRepo { get; }
        Task<int> SaveChangesAsync();
    }
}