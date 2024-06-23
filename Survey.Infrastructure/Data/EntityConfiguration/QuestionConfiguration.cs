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
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
            public void Configure(EntityTypeBuilder<Question> builder)
            {
                builder.HasKey(i => i.Id);

                builder.HasMany(i => i.Choices)
                       .WithOne(i => i.Question)
                       .HasForeignKey(i => i.QuestionId);

                builder.HasOne(i => i.QType)
                       .WithMany(i => i.Questions)
                       .HasForeignKey(i => i.QTypeId);



            var questions = new List<Question>
            {
                 // Questions
                        new Question{Id = 1, Text = "Do you have AWS certificate?", Order = 1, QTypeId = 1, SurveyId = 2, IsDeleted=false},
                        new Question{Id = 2, Text = "Upload your AWS certificate", Order = 2, QTypeId = 4, SurveyId = 2, IsDeleted=false},
                        new Question{Id = 3, Text = "Describe your work experience in a nutshell", Order = 3, QTypeId = 3, SurveyId = 2, IsDeleted=false},
                        new Question{Id = 4, Text = "What is your blood type?", Order = 1, QTypeId = 1, SurveyId = 1, IsDeleted=false},
                        new Question{Id = 5, Text = "Do you suffer from any heart disease", Order = 2, QTypeId = 1, SurveyId = 1, IsDeleted=false},
                        new Question{Id = 6, Text = "Please, Mention any disease related to heart", Order = 3, QTypeId = 3, SurveyId = 1, IsDeleted=false},
                        new Question{Id = 7, Text = "Choose your medical department in collage", Order = 4, QTypeId = 1, SurveyId = 1, IsDeleted=false},
                        new Question{Id = 8, Text = "Tell us a brief about your medical history", Order = 5, QTypeId = 3, SurveyId = 1, IsDeleted=false},
                        new Question{Id = 9, Text = "Choose What suits you as a working option", Order = 1, QTypeId = 2, SurveyId = 3, IsDeleted=false},
                        new Question{Id = 10, Text = "Tell us about your educational experience", Order = 2, QTypeId = 3, SurveyId = 3, IsDeleted=false},
            };
            //builder.HasData(questions);
        }
    }
}
