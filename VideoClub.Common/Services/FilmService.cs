using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class FilmService : IFilmService
    {
        private readonly VideoClubDbContext _context;

        public FilmService(VideoClubDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Film> GetAll()
        {
            return _context.Films
                .Include(f => f.Copies)
                .AsNoTracking();
        }
        
        public IEnumerable<Film> GetAvailable()
        {
            return _context.Films
                .Include(f => f.Copies)
                .Where(f=> f.Copies.Any(c => c.IsAvailable))
                .AsNoTracking();
        }

        public Film Get(int id)
        {
            return _context.Films
                .Include(f => f.Copies)
                .FirstOrDefault(f => f.Id == id);
        }

        public void Add(Film film)
        {
            _context.Films.Add(film);
            _context.SaveChanges();
        }
    }
}