using System;

namespace VideoClub.Core.Entities
{
    public class Rental
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public int CopyId { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}