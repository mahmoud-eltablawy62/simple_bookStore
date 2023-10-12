using Repository_Pattern.core.Interfaces;
using Repository_Pattern.core.Models; 

namespace Repository_Pattern.EF.Repositries
{
    public class BookRepository : repositiry<Book>, IBookRepository
    {
        private readonly AppDbContext _Context;
        public BookRepository(AppDbContext Context) : base(Context) { }
     
        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
