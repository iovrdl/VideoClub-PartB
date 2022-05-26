using System.Collections.Generic;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer Get(string id);
        void Add(Customer customer);
    }
}