using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Enumeration;
using VideoClub.Infrastructure.Data;
using VideoClub.Infrastructure.Models;
using VideoClub.Infrastructure.Models.Dtos;
using VideoClub.Infrastructure.Services.Interfaces;

namespace VideoClub.Infrastructure.Services.Implementations
{
    public class PaginationService : IPaginationService
    {
        private readonly VideoClubDbContext _context;

        public PaginationService(VideoClubDbContext context)
        {
            _context = context;
        }

        public async Task<PaginationModel<Film>> GetPaginatedFilms(PaginationDto pagination, string search,
            Genre? genre)
        {
            var filmsQuery = _context.Films
                .Include(f => f.Copies)
                .OrderBy(f => f.Id)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                filmsQuery = filmsQuery
                    .Where(f => f.Title.Contains(search))
                    .AsQueryable();
            }

            if (genre != null)
            {
                filmsQuery = filmsQuery
                    .Where(f => f.Genre == genre)
                    .AsQueryable();
            }

            var totalFilms = await filmsQuery.CountAsync();

            filmsQuery = filmsQuery
                .Skip(pagination.ToSkip())
                .Take(pagination.ItemsPerPage);

            var films = await filmsQuery.ToListAsync();

            return new PaginationModel<Film>(films, pagination.CurrentPage, pagination.ItemsPerPage, totalFilms);
        }
    }
}