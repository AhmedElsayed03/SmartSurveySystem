using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.EntityConfiguration
{
    public class MemberSurveyConfiguration : IEntityTypeConfiguration<MemberSurvey>
    {
            public void Configure(EntityTypeBuilder<MemberSurvey> builder)
            {
            builder.HasKey(i => new { i.MemberId, i.SurveyId });

            builder.HasOne(i => i.Member)
                   .WithMany(i => i.MemberSurveys)
                   .HasForeignKey(i => i.MemberId);

            builder.HasOne(i => i.Survey)
                   .WithMany(i => i.MemberSurveys)
                   .HasForeignKey(i => i.SurveyId);


            var memberSurveys = new List<MemberSurvey>
            {
                 // MemberSurveys
                        new MemberSurvey{MemberId = 1, SurveyId= 2},
                        new MemberSurvey{MemberId = 2, SurveyId= 2},
                        new MemberSurvey{MemberId = 3, SurveyId= 1},
                        new MemberSurvey{MemberId = 1, SurveyId= 3},
            };
            builder.HasData(memberSurveys);
        }
    }
}
