using TourAPI.Models;

namespace TourAPI.Interfaces
{
    public interface IRepo<K,T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int key);
        Task<T> Add(T item);
        Task<T> Update(T item);
        Task<T> Delete(int key);

    }
}
