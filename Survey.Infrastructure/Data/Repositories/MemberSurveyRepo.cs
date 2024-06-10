using Survey.Application.Abstractions.Repositories;
using Survey.Domain.Entities;
using Survey.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.Repositories
{
    public class MemberSurveyRepo : GenericRepo<MemberSurvey>, IMemberSurveyRepo
    {
        private readonly SurveyDbContext _dbContext;

        public MemberSurveyRepo(SurveyDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
