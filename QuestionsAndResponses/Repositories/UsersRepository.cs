
using QuestionsAndResponses.Data;
using QuestionsAndResponses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext context;

        public UsersRepository(ApplicationDbContext context)
        {
            this.context = context;        
        }
        public void Delete(User item)
        {
            context.Remove(item);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList<User>();
        }

        public User GetItem(int id)
        {
            return context.Users.Find(id);
        }

        public void Save(User item)
        {
            if(item.Id == 0)
            {
                item.CreatedIn = DateTime.Now;
                context.Users.Add(item);
            }
            else 
            {
                var user = GetItem(item.Id);
                user.EMail = item.EMail;
                user.Name = item.Name;
                user.Password = item.Password;
            }
            context.SaveChanges();
        }

        public IEnumerable<User> SearchAll(Filters.UserFilter filter)
        {
            IEnumerable<User> response = context.Users;
            if (!string.IsNullOrEmpty(filter.Name))
            {
                response = response.Where(x => x.Name.Contains(filter.Name));
            }
            if (!string.IsNullOrEmpty(filter.EMail))
            {
                response = response.Where(x => x.EMail == filter.EMail);
            }
            if (!string.IsNullOrEmpty(filter.Password))
            {
                response = response.Where(x => x.Password == filter.Password);
            }
            return response.ToList<User>();
        }
    }
}
