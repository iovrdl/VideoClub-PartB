using System.Collections.Generic;
using VideoClub.Core.Enumeration;

namespace VideoClub.Core.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public List<Copy> Copies { get; set; }

        public Film()
        {
            Copies = new List<Copy>();
        }
    }
}