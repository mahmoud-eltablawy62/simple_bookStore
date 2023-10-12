using Repository_Pattern.core;
using Repository_Pattern.core.Interfaces;
using Repository_Pattern.core.Models;
using Repository_Pattern.EF.Repositries;


namespace Repository_Pattern.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _Context;
        public Irepositiry<Author> Authors { get; private set; }
        public IBookRepository Books { get; private set; }

        public UnitOfWork(AppDbContext Context)
        {
            _Context = Context;
            Authors = new repositiry<Author>(_Context);
            Books = new BookRepository (_Context);

        }

         public int Complete()
        {
           return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();  
        }
    }
}
