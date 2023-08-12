using TourAPI.Models;
using TourAPI.Models.DTOs;

namespace TourAPI.Interfaces
{
    public interface IAgentTourService
    {
        Task<Tour> AddNewTour(Tour tour);
        Task<Tour> UpdatePrice(TourPriceUpdateDTO tour);
    }
}
