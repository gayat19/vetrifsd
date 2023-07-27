using System.Runtime.InteropServices;
using TourAPI.Models;

namespace TourAPI.Interfaces
{
    public interface ITourService
    {
        Tour GetTourByName(string name);
        IEnumerable<Tour> GetTourWithinRange(float min, float max);

        Tour AddNewTour(Tour tour);
        Tour UpdatePrice(int id,float price);   
    }
}
