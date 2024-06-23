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
    public class SurveyConfiguration : IEntityTypeConfiguration<Domain.Entities.Survey>
    {
            public void Configure(EntityTypeBuilder<Domain.Entities.Survey> builder)
            {
                builder.HasKey(i => i.Id);

            builder.HasMany(i => i.Questions)
                       .WithOne(i => i.Survey)
                       .HasForeignKey(i => i.SurveyId);

            var surveys = new List<Domain.Entities.Survey>
                {
                    // Surveys
                    new Domain.Entities.Survey { Id = 1, Name = "Medical", CreateTime = DateTime.Now },
                    new Domain.Entities.Survey { Id = 2, Name = "Technical", CreateTime = DateTime.Now },
                    new Domain.Entities.Survey { Id = 3, Name = "Educational", CreateTime = DateTime.Now },
                };
            builder.HasData(surveys);
        }
    }
}
