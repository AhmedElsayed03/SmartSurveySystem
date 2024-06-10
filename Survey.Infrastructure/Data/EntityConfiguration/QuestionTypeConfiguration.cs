using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey.Domain.Entities;
using Survey.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Infrastructure.Data.EntityConfiguration
{
    public class QuestionTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {

        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.HasKey(i => i.Id);

            var questionTypes = new List<QuestionType>
            {
                 // QuestionTypes
                        new QuestionType {Id = 1, QuestionTypeEnum = QuestionTypeEnum.Choice, QuestionTypeString="Choices"},
                        new QuestionType {Id = 2, QuestionTypeEnum = QuestionTypeEnum.MultipleChoices, QuestionTypeString="MultipleChoices"},
                        new QuestionType {Id = 3, QuestionTypeEnum = QuestionTypeEnum.InputText, QuestionTypeString="InputText"},
                        new QuestionType {Id = 4, QuestionTypeEnum = QuestionTypeEnum.FileUpload, QuestionTypeString="FileUpload"},

            };
            builder.HasData(questionTypes);



        }
    }
}
