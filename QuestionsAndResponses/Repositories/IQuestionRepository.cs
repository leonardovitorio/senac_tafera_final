

using QuestionsAndResponses.Models;
using QuestionsAndResponses.Repositories.Filters;

namespace QuestionsAndResponses.Repositories
{
    public interface IQuestionRepository : IRepository<Question, QuestionFilter>
    {
    }
}
