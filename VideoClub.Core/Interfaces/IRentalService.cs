using System.Collections.Generic;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IRentalService
    {
        IEnumerable<Rental> GetAll();
        IEnumerable<Rental> GetActive();
        IEnumerable<Rental> GetInActive();
        IEnumerable<Rental> GetByCustomerId(string customerId);
        Rental Get(int id);
        void Add(Rental rental);
        void UpdateIsActive(int id, bool isActive);
    }
}