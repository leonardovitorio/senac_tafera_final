
using QuestionsAndResponses.Data;
using QuestionsAndResponses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext context;

        public QuestionRepository(ApplicationDbContext context)
        {
            this.context = context;        
        }
        public void Delete(Question item)
        {
            context.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<Question> GetAll()
        {
            return context.Questions.ToList<Question>();
        }

        public Question GetItem(int id)
        {
            return this.context.Questions.Find(id);
        }

        public void Save(Question item)
        {
            if(item.Id == 0)
            {
                context.Questions.Add(item);
            }
            else
            {
                var question = GetItem(item.Id);
                question.Description = item.Description;
            }
            context.SaveChanges();
        }

        public IEnumerable<Question> SearchAll(Filters.QuestionFilter filter)
        {
            IEnumerable<Question> response = context.Questions;
            if (filter.UserId != null)
            {
                response = response.Where(x => x.UserId == filter.UserId);
            }
            if (!string.IsNullOrEmpty(filter.Description))
            {
                response = response.Where(x => x.Description.Contains(filter.Description));
            }
            return response.ToList<Question>();
        }
    }
}
