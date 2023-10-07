

namespace Repository_Pattern.core.Interfaces
{
     public interface Irepositiry <T> where T : class
    {
        T GetValue(int id);    
    }
}
