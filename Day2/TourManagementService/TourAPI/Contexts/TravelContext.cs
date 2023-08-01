using Microsoft.EntityFrameworkCore;
using TourAPI.Models;

namespace TourAPI.Contexts
{
    public class TravelContext :DbContext
    {
        public TravelContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Tour> Tours { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tour>().HasData(new Tour { Id = 101, Name = "Japan", Price = 150000.4f },
        new Tour { Id = 102, Name = "China", Price = 200000.0f });
        }
    }
}
