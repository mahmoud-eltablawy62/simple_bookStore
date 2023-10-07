using Repository_Pattern.core.Interfaces;


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
    }
  
}
