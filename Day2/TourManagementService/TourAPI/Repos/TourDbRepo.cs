using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TourAPI.Contexts;
using TourAPI.Interfaces;
using TourAPI.Models;

namespace TourAPI.Repos
{
    public class TourDbRepo : IRepo<int, Tour>
    {
        private readonly TravelContext _context;
        private readonly ILogger<TourDbRepo> _logger;

        public TourDbRepo(TravelContext context,ILogger<TourDbRepo> logger)
        {
            _context=context;
            _logger = logger;
        }
        public Tour Add(Tour item)
        {
            try
            {
                _context.Tours.Add(item);
                _context.SaveChanges();
                _logger.LogInformation("Created tour successfully with id " + item.Id);
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogCritical("Unable to create tour");
            }
            return null;

        }

        public Tour Delete(int key)
        {
            var tour = Get(key);
            if(tour != null)
            {
                try
                {
                    _context.Tours.Remove(tour);
                    _context.SaveChanges();
                    _logger.LogInformation("Deleted tour successfully with id " + tour.Id);
                    return tour;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    _logger.LogCritical("Unable to delete tour");
                }
            }
           
            return null;
        }

        public Tour Get(int key)
        {
            var tour = _context.Tours.FirstOrDefault(tour => tour.Id == key);
            return tour;
        }

        public IEnumerable<Tour> GetAll()
        {
            var tours = _context.Tours.ToList();
            if (tours.Count > 0)
                return tours;
            return null;
        }

        public Tour Update(Tour item)
        {
            var myTtour = Get(item.Id);
            if (myTtour != null)
            {
                try
                {
                    _context.Update(item);
                    _context.SaveChanges();
                    _logger.LogInformation("Updated tour successfully with id " + item.Id);
                    return item;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    _logger.LogCritical("Unable to update tour");
                }
            }

            return null;
        }
    }
}
