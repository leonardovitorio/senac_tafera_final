using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Models.User> Users { get; set; }
        public DbSet<Models.Question> Questions { get; set; }
        public DbSet<Models.Response> Responses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
