using System;
using System.Collections.Generic;
using VideoClub.Core.Entities;

namespace VideoClub.Web.Areas.Rentals.Models
{
    public class CreateRentalBindingModel
    {
        public int FilmId { get; set; }
        public string CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Note { get; set; }
        public List<Film> Films { get; set; }
        public List<Customer> Customers { get; set; }

        public CreateRentalBindingModel()
        {
            var now = DateTime.UtcNow;
            RentalDate = now;
            ReturnDate = now.AddDays(7);
        }
    }
}