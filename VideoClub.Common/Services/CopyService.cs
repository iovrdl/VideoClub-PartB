using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using VideoClub.Core.Entities;
using VideoClub.Core.Interfaces;
using VideoClub.Infrastructure.Data;

namespace VideoClub.Common.Services
{
    public class CopyService : ICopyService
    {
        private readonly VideoClubDbContext _context;

        public CopyService(VideoClubDbContext context)
        {
            _context = context;
        }

        public Copy GetFirstAvailable(int filmId)
        {
            return _context.Films
                .Include(f => f.Copies)
                .FirstOrDefault(f => f.Id == filmId)?.Copies
                .FirstOrDefault(c => c.IsAvailable);
        }

        public void Add(Copy copy)
        {
            _context.Copies.Add(copy);
            _context.SaveChanges();
        }

        public void Add(int filmId, int totalCopies)
        {
            var copiesList = new List<Copy>();

            for (var i = 0; i < totalCopies; i++)
            {
                copiesList.Add(new Copy
                {
                    FilmId = filmId,
                    IsAvailable = true
                });
            }

            _context.Copies.AddRange(copiesList);
            _context.SaveChanges();
        }

        public void UpdateIsAvailable(int copyId, bool isAvailable)
        {
            var copy = _context.Copies.FirstOrDefault(c => c.Id == copyId);
            if (copy == null)
            {
                return;
            }

            copy.IsAvailable = isAvailable;

            var entry = _context.Entry(copy);
            entry.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}