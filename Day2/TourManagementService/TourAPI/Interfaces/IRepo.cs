using TourAPI.Models;

namespace TourAPI.Interfaces
{
    public interface IRepo<K,T>
    {
        IEnumerable<T> GetAll();
        T Get(int key);
        T Add(Tour item);
        T Update(Tour item);
        T Delete(int key);

    }
}
