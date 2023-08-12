using Microsoft.AspNetCore.DataProtection.KeyManagement;
using TourAPI.Interfaces;
using TourAPI.Models;

namespace TourAPI.Repos
{
    public class TourRepo : IRepo<int, Tour>
    {
        static List<Tour> tours = new List<Tour>() { new Tour {Id=101,Name="Euroupe Ext",Price=150000.4f } ,
        new Tour {Id=102,Name="USA",Price=200000.0f}};

        public async Task<Tour> Add(Tour item)
        {
           tours.Add(item);
            return item;
        }

        public async Task<Tour> Delete(int key)
        {
            var tour = await Get(key);
            if(tour != null)
            {
                tours.Remove(tour);
                return tour;
            }
            return null;
        }

        public async Task<Tour>  Get(int key)
        {
            var tour = tours.FirstOrDefault(tour => tour.Id == key);
            return tour;
        }

        public async Task<IEnumerable<Tour>> GetAll()
        {
           if(tours.Count>0)
                return tours;
            return null;
        }

        public async Task<Tour> Update(Tour item)
        {
            var tour = await Get(item.Id);
            if (tour != null)
            {
                tour.Name = item.Name;
                tour.Price = item.Price;
                tour.Description  = item.Description;
                return tour;
            }
            return null;
        }
    }
}
