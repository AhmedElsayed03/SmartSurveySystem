using Survey.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Application.Abstractions.Services
{
    public interface IQuestionService
    {
        Task AddQuestionAsync(QuestionAddDto newQuestion);
        Task<QuestionReadDto?> GetQuestionAsync(int id);
        Task<QuestionWithChoicesReadDto?> GetQuestionWithChoicesAsync(int id);
        Task<int> GetNextQuestionId(int questionId, int nextQuestionOrder);
    }
}
