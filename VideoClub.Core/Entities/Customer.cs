using System.Collections.Generic;

namespace VideoClub.Core.Entities
{
    public class Customer : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Rental> Rentals { get; set; }

        public Customer()
        {
            Rentals = new List<Rental>();
        }
    }
}