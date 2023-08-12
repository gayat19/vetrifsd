using System.Xml.Linq;
using TourAPI.Interfaces;
using TourAPI.Models;
using TourAPI.Models.DTOs;
using TourAPI.Repos;


namespace TourAPI.Services
{
    public class TourService :ICustomerTourService,IAgentTourService
    {
        private readonly IRepo<int, Tour> _tourRepo = new TourRepo();

        public TourService(IRepo<int,Tour> tourRepo)
        { 
            _tourRepo = tourRepo;
        }

        private async Task<List<Tour>> _GetTours()
        {
           return (await _tourRepo.GetAll()).ToList();
        }
        public async Task<Tour> GetTourByName(string name)
        {
            var tours = await _GetTours();
            var tour = tours?.FirstOrDefault(t => t.Name == name);
            return tour;
        }

        public async Task<IEnumerable<Tour>> GetTourWithinRange(float min, float max)
        {
            var tours = await _GetTours();
            var myTours = tours.Where(t => t.Price >= min && t.Price <= max).ToList();
            if(myTours?.Count()>0)
                return myTours;
            return null;
        }

        public async Task<Tour> AddNewTour(Tour tour)
        {
            var mytour = await _tourRepo.Get(tour.Id);
            if(mytour == null)
            {
                await _tourRepo.Add(tour);
                return tour;
            }
            return null;
        }

        public async Task<Tour> UpdatePrice(TourPriceUpdateDTO tour)
        {
            Tour mytour = await _tourRepo.Get(tour.Id);
            if (tour != null)
            {
                mytour.Price = tour.Price;
                await _tourRepo.Update(mytour);
                return mytour;
            }
            return null;
        }

       

    }
}
