using System.Runtime.InteropServices;
using TourAPI.Models;

namespace TourAPI.Interfaces
{
    public interface ICustomerTourService
    {
        Task<Tour> GetTourByName(string name);
        Task<IEnumerable<Tour>> GetTourWithinRange(float min, float max);

        
    }
}
