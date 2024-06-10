using Survey.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Survey.Domain.Entities;
using Survey.Infrastructure.Data.Context;

namespace Survey.Infrastructure.Data.Repositories
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly SurveyDbContext _dbContext;

        public MemberRepo(SurveyDbContext context) : base(context)
        {
            _dbContext = context;
        }
    }
}
