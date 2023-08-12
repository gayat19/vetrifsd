using Microsoft.Data.SqlClient;
using System.Diagnostics;
using TourAPI.Common.UserDefinedExceptions;
using TourAPI.Contexts;
using TourAPI.Interfaces;
using TourAPI.Models;

namespace TourAPI.Repos
{
    public class CustomerRepo : IRepo<int, Customer>
    {
        private readonly TravelContext _context;

        public CustomerRepo(TravelContext context) {
            _context = context;
        }

        public async Task<Customer> Add(Customer item)
        {
            try
            {
                _context.Customers.Add(item);
               await _context.SaveChangesAsync();
                return item;
            }
            catch (SqlException sqlException)
            {
                throw new CustomerSqlException(item.Name);
                Debug.WriteLine(sqlException.Message);
            }

        }

        public Task<Customer> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
