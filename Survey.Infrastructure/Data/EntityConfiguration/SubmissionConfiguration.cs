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
    public class SubmissionConfiguration : IEntityTypeConfiguration<Submission>
    {
        public void Configure(EntityTypeBuilder<Submission> builder)
        {

            builder.HasKey(i => i.Id);


            builder.HasOne(i => i.Member)
                   .WithMany(i => i.Submissions)
                   .HasForeignKey(i => i.MemberId)
                   .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(i => i.Choice)
                   .WithMany(i => i.Submissions)
                   .HasForeignKey(i => i.ChoiceId)
                   .OnDelete(DeleteBehavior.NoAction);

            //builder.HasOne(i => i.Question)
            //       .WithMany(i => i.Submissions)
            //       .HasForeignKey(i => i.QuestionId);
            //.OnDelete(DeleteBehavior.NoAction); 

            var submissions = new List<Submission>
            {
                 // Submissions
                        //new Submission {Id = 1, MemberId = 1, ChoiceId = 1, QuestionId = 1, Text = "Yes, I have AWS certificate", CreateTime = DateTime.Now},
                        //new Submission {Id = 2, MemberId = 1, ChoiceId = 0, QuestionId = 2, Text = "url.com/aws_cv.pdf", CreateTime = DateTime.Now},
                        //new Submission {Id = 3, MemberId = 1, ChoiceId = 0, QuestionId = 3, Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now},
                        //new Submission {Id = 4, MemberId = 2, ChoiceId = 2, QuestionId = 1, Text = "No, I don't have AWS certificate", CreateTime = DateTime.Now},
                        //new Submission {Id = 5, MemberId = 2, ChoiceId = 0, QuestionId = 3, Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now},
                        //new Submission {Id = 6, MemberId = 3, ChoiceId = 3, QuestionId = 4, Text = "A+", CreateTime = DateTime.Now},
                        //new Submission {Id = 7, MemberId = 3, ChoiceId = 6, QuestionId = 5, Text = "Yes, I have some health problems", CreateTime = DateTime.Now},
                        //new Submission {Id = 8, MemberId = 3, ChoiceId = 0, QuestionId = 6, Text = "I have Cardiomyopathy", CreateTime = DateTime.Now},
                        //new Submission {Id = 9, MemberId = 3, ChoiceId = 9, QuestionId = 7, Text = "Dermatology", CreateTime = DateTime.Now},
                        //new Submission {Id = 10, MemberId = 3, ChoiceId = 0, QuestionId = 8, Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now},
                        //new Submission {Id = 11, MemberId = 1, ChoiceId = 11, QuestionId = 9, Text = "On-Site", CreateTime = DateTime.Now},
                        //new Submission {Id = 12, MemberId = 1, ChoiceId = 12, QuestionId = 9, Text = "Remote", CreateTime = DateTime.Now},
                        //new Submission {Id = 13, MemberId = 1, ChoiceId = 13, QuestionId = 9, Text = "Hybrid", CreateTime = DateTime.Now},
                        new Submission {Id = 14, MemberId = 1, ChoiceId = 0, Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now},                      //new Submission {Id = 1, MemberId = 1, ChoiceId = 1, QuestionId = 1, Text = "Yes, I have AWS certificate", CreateTime = DateTime.Now},
                        new Submission {Id = 2, MemberId = 1, ChoiceId = 0, Text = "url.com/aws_cv.pdf", CreateTime = DateTime.Now},
                        new Submission {Id = 3, MemberId = 1, ChoiceId = 0, Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now},
                        new Submission {Id = 4, MemberId = 2, ChoiceId = 2, Text = "No, I don't have AWS certificate", CreateTime = DateTime.Now},
                        new Submission {Id = 5, MemberId = 2, ChoiceId = 0, Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now},
                        new Submission {Id = 6, MemberId = 3, ChoiceId = 3, Text = "A+", CreateTime = DateTime.Now},
                        new Submission {Id = 7, MemberId = 3, ChoiceId = 6, Text = "Yes, I have some health problems", CreateTime = DateTime.Now},
                        new Submission {Id = 8, MemberId = 3, ChoiceId = 0, Text = "I have Cardiomyopathy", CreateTime = DateTime.Now},
                        new Submission {Id = 9, MemberId = 3, ChoiceId = 9, Text = "Dermatology", CreateTime = DateTime.Now},
                        new Submission {Id = 10, MemberId = 3, ChoiceId = 0, Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now},
                        new Submission {Id = 11, MemberId = 1, ChoiceId = 11, Text = "On-Site", CreateTime = DateTime.Now},
                        new Submission {Id = 12, MemberId = 1, ChoiceId = 12,  Text = "Remote", CreateTime = DateTime.Now},
                        new Submission {Id = 13, MemberId = 1, ChoiceId = 13,  Text = "Hybrid", CreateTime = DateTime.Now},
                        new Submission {Id = 14, MemberId = 1, ChoiceId = 0,  Text = "Lorem ipsum is placeholder text commonly used in the graphic, print, and publishing industries for previewing layouts and visual mockups.", CreateTime = DateTime.Now}
            };
            builder.HasData(submissions);
        }
    }
}
