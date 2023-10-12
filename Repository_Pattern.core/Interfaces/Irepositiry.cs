

using Repository_Pattern.core.consts;
using System.Linq.Expressions;

namespace Repository_Pattern.core.Interfaces
{
     public interface Irepositiry <T> where T : class
    {
        T GetValue(int id);    
        IEnumerable<T> GetAll();    
        T Find(Expression<Func<T, bool>> Match , string[] includes = null);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> Match, string[] includes = null);
        IEnumerable<T> findAll(Expression<Func<T, bool>> Match, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string OrderByDirection = OrderBy.Ascending);
        T Add(T entity);
        T Update (T entity);
        void Delete(T entity);
        int Count();
        int Conut(Expression<Func<T, bool>> Match);
    }
}
