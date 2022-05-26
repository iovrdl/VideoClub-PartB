using System.Threading.Tasks;
using VideoClub.Core.Entities;
using VideoClub.Core.Enumeration;
using VideoClub.Infrastructure.Models;
using VideoClub.Infrastructure.Models.Dtos;

namespace VideoClub.Infrastructure.Services.Interfaces
{
    public interface IPaginationService
    {
        Task<PaginationModel<Film>> GetPaginatedFilms(PaginationDto pagination, string search, Genre? genre);
    }
}