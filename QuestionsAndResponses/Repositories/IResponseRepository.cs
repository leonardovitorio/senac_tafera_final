
using QuestionsAndResponses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Repositories
{
    public interface IResponseRepository : IRepository<Response, Filters.ResponseFilter>
    {
    }
}
