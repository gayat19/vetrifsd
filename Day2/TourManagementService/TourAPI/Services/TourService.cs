using System.Xml.Linq;
using TourAPI.Interfaces;
using TourAPI.Models;
using TourAPI.Repos;

namespace TourAPI.Services
{
    public class TourService :ITourService
    {
        private readonly IRepo<int, Tour> _tourRepo = new TourRepo();

        public TourService(IRepo<int,Tour> tourRepo)
        { 
            _tourRepo = tourRepo;
        }

        private List<Tour> _GetTours()
        {
           return _tourRepo.GetAll().ToList();
        }
        public Tour GetTourByName(string name)
        {
            var tours = _GetTours();
            var tour = tours?.FirstOrDefault(t => t.Name == name);
            return tour;
        }

        public IEnumerable<Tour> GetTourWithinRange(float min, float max)
        {
            var tours = _GetTours();
            var myTours = tours.Where(t => t.Price >= min && t.Price <= max).ToList();
            if(myTours?.Count()>0)
                return myTours;
            return null;
        }

        public Tour AddNewTour(Tour tour)
        {
            var mytour = _tourRepo.Get(tour.Id);
            if(mytour == null)
            {
                _tourRepo.Add(tour);
                return tour;
            }
            return null;
        }

        public Tour UpdatePrice(int id, float price)
        {
            var tour = _tourRepo.Get(id);
            if (tour != null)
            {
                tour.Price = price;
                _tourRepo.Update(tour);
                return tour;
            }
            return null;
        }

       

    }
}
