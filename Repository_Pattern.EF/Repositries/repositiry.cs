using Microsoft.EntityFrameworkCore;
using Repository_Pattern.core.consts;
using Repository_Pattern.core.Interfaces;
using System.Linq.Expressions;
namespace Repository_Pattern.EF.Repositries
{
    public class repositiry<T> : Irepositiry<T> where T : class
    {
        protected AppDbContext _Context { get; set; }

        public repositiry(AppDbContext Context)
        {
            _Context = Context;
        }
        public T GetValue(int id)
        {
            return _Context.Set<T>().Find(id);
        }

        public IEnumerable<T> GetAll()  
        {
            return _Context.Set<T>().ToList();
        }

        public T Find(Expression<Func<T, bool>> Match, string[] includes = null)
        {
            IQueryable<T> Quary = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    Quary = Quary.Include(item);
                }
            }
            return Quary.SingleOrDefault(Match);
        }
        IEnumerable<T> Irepositiry<T>.FindAll(Expression<Func<T, bool>> Match, string[] includes = null)
        {
            IQueryable<T> Quary = _Context.Set<T>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    Quary = Quary.Include(item);
                }
            }
            return Quary.Where(Match).ToList();
        }

        IEnumerable<T> Irepositiry<T>.findAll(Expression<Func<T, bool>> Match, int? take, int? skip,
           Expression<Func<T, object>> orderBy = null, string OrderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> Quary = _Context.Set<T>().Where(Match);
            if(take.HasValue)
                Quary = Quary.Take(take.Value);

            if (skip.HasValue)
                Quary = Quary.Skip(skip.Value); 

            if(orderBy != null)
            {
                if(OrderByDirection == OrderBy.Ascending)
                    Quary = Quary.OrderBy(orderBy); 
                else 
                    Quary = Quary.OrderByDescending(orderBy);   
            }
            return Quary.ToList();
        }
         public T Add(T entity)
        {
            _Context.Set<T>().Add(entity);
            _Context.SaveChanges();
            return entity;  
        }

        public T Update(T entity)
        {
            _Context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
        }

        public int Count()
        {
            return  _Context.Set<T>().Count();
        }

         public int Conut(Expression<Func<T, bool>> Match)
        {
            return _Context.Set<T>().Count(Match);
        }

      
    }
}
