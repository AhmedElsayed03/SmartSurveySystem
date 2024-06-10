using Survey.Application.Abstractions.Repositories;
using Survey.Application.Abstractions.Services;
using Survey.Application.Abstractions.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Identity.Services
{
    public class MemberSurveyService : IMemberSurveyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public MemberSurveyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


    }
}
