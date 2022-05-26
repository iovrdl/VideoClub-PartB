using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class RentalService : IRentalService
    {
        private readonly VideoClubDbContext _context;

        public RentalService(VideoClubDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Rental> GetAll()
        {
            return _context.Rentals
                .Include(r => r.Film)
                .Include(r => r.Customer)
                .AsNoTracking();
        }

        public IEnumerable<Rental> GetActive()
        {
            return _context.Rentals
                .Where(r => r.IsActive)
                .Include(r => r.Film)
                .Include(r => r.Customer)
                .AsNoTracking();
        }

        public IEnumerable<Rental> GetInActive()
        {
            return _context.Rentals
                .Where(r => !r.IsActive)
                .Include(r => r.Film)
                .Include(r => r.Customer)
                .AsNoTracking();
        }
        
        public IEnumerable<Rental> GetByCustomerId(string customerId)
        {
            return _context.Rentals
                .Where(r => r.CustomerId.Equals(customerId))
                .Where(r => r.IsActive)
                .Include(r => r.Film)
                .Include(r => r.Customer)
                .AsNoTracking();
        }

        public Rental Get(int id)
        {
            return _context.Rentals
                .Include(r => r.Film)
                .Include(r => r.Customer)
                .FirstOrDefault(r => r.Id == id);
        }

        public void Add(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }

        public void UpdateIsActive(int id, bool isActive)
        {
            var rental = _context.Rentals.FirstOrDefault(r => r.Id == id);
            if (rental == null)
            {
                return;
            }

            rental.IsActive = isActive;

            var entry = _context.Entry(rental);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}