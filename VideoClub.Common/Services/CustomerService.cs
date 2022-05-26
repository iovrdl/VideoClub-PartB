using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly VideoClubDbContext _context;

        public CustomerService(VideoClubDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.AsNoTracking();
        }

        public Customer Get(string id)
        {
            return _context.Customers
                .Include(c => c.Rentals)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
}