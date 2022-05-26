namespace VideoClub.Core.Entities
{
    public class Copy
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
        public bool IsAvailable { get; set; }
    }
}