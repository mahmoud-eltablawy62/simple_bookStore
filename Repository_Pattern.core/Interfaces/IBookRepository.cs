using Repository_Pattern.core.Models;


namespace Repository_Pattern.core.Interfaces
{
    public interface IBookRepository : Irepositiry<Book>
    {
        IEnumerable<Book> SpecialMethod(); 
    }
}
