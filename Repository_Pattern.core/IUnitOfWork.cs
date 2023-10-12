using Repository_Pattern.core.Interfaces;
using Repository_Pattern.core.Models;


namespace Repository_Pattern.core
{
     public interface IUnitOfWork : IDisposable
    {
        Irepositiry<Author> Authors { get; }

        IBookRepository Books { get; }

        int Complete();
    }
}
