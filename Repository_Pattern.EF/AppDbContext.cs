using Microsoft.EntityFrameworkCore;
using Repository_Pattern.core.Models;


namespace Repository_Pattern.EF
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }
        public DbSet<Author> Authors { get; set; }  
        public DbSet<Book> Books { get; set; }  
    }
}
