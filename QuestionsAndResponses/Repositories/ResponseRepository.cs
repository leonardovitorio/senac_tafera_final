
using QuestionsAndResponses.Data;
using QuestionsAndResponses.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionsAndResponses.Repositories
{
    public class ResponseRepository : IResponseRepository
    {
        private readonly ApplicationDbContext context;

        public ResponseRepository(ApplicationDbContext context)
        {
            this.context = context;        
        }
        public void Delete(Response item)
        {
            context.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<Response> GetAll()
        {
            return context.Responses.ToList<Response>();
        }

        public Response GetItem(int id)
        {
            return this.context.Responses.Find(id);
        }

        public void Save(Response item)
        {
            if (item.Id == 0)
            {
                context.Responses.Add(item);
            }
            else
            {
                var response = GetItem(item.Id);
                response.Description = item.Description;
            }
            context.SaveChanges();
        }

        public IEnumerable<Response> SearchAll(Filters.ResponseFilter filter)
        {
            IEnumerable<Response> response = context.Responses;
            if (filter.UserId != null)
            {
                response = response.Where(x => x.UserId == filter.UserId);
            }
            if (filter.QuestionId != null)
            {
                response = response.Where(x => x.QuestionId == filter.QuestionId);
            }
            if (!string.IsNullOrEmpty(filter.Description))
            {
                response = response.Where(x => x.Description.Contains(filter.Description));
            }
            return response.ToList<Response>();
        }
    }
}
