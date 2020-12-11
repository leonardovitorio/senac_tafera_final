using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionsAndResponses.Repositories
{
    public interface IRepository<T,F>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> SearchAll(F filter);
        T GetItem(int id);
        void Save(T item);
        void Delete(T item);
    }
}
