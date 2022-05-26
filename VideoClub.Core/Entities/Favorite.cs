using VideoClub.Core.Enumeration;

namespace VideoClub.Core.Entities
{
    public class Favorite
    {
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Genre Genre { get; set; }
    }
}