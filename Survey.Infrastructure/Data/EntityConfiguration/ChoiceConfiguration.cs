using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Survey.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.EntityConfiguration
{
    public class ChoiceConfiguration : IEntityTypeConfiguration<Choice>
        {
            public void Configure(EntityTypeBuilder<Choice> builder)
            {
                builder.HasKey(i => i.Id);



            var choices = new List<Choice>
                {
                     // choices

                        //choices for Question 1
                            new Choice {Id = 1, QuestionId = 1, Text = "Yes, I have AWS certificate", Order = 1 , Next_Question_Order = 0},
                            new Choice {Id = 2, QuestionId = 1, Text = "No, I don't have AWS certificate", Order = 2 , Next_Question_Order = 3},

                        //choices for Question 4
                            new Choice {Id = 3, QuestionId = 4, Text = "A+", Order = 1 , Next_Question_Order = 0},
                            new Choice {Id = 4, QuestionId = 4, Text = "O-", Order = 2 , Next_Question_Order = 0},
                            new Choice {Id = 5, QuestionId = 4, Text = "B+", Order = 3 , Next_Question_Order = 0},

                        //choices for Question 5
                            new Choice {Id = 6, QuestionId = 5, Text = "Yes, I have some health problems", Order = 1 , Next_Question_Order = 0},
                            new Choice {Id = 7, QuestionId = 5, Text = "No, I don't have any disease", Order = 2 , Next_Question_Order = 4},

                        //choices for Question 7
                            new Choice {Id = 8, QuestionId = 7, Text = "Neurology", Order = 1 , Next_Question_Order = 5},
                            new Choice {Id = 9, QuestionId = 7, Text = "Dermatology", Order = 2 , Next_Question_Order = 5},
                            new Choice {Id = 10, QuestionId = 7, Text = "Orthopedic Surgery", Order = 3 , Next_Question_Order = 5},

                        //choices for Question 9
                            new Choice {Id = 11, QuestionId = 9, Text = "On-Site", Order = 1 , Next_Question_Order = 0},
                            new Choice {Id = 12, QuestionId = 9, Text = "Remote", Order = 2 , Next_Question_Order = 0},
                            new Choice {Id = 13, QuestionId = 9, Text = "Hybrid", Order = 3 , Next_Question_Order = 0},

                };
            builder.HasData(choices);


        }

    }
}
