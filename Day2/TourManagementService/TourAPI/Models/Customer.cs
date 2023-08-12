using System.ComponentModel.DataAnnotations;

namespace TourAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Customer name cannot be null")]
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
