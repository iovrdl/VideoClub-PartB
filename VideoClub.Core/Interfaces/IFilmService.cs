using System.Collections.Generic;
using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface IFilmService
    {
        IEnumerable<Film> GetAll();
        IEnumerable<Film> GetAvailable();
        Film Get(int id);
        void Add(Film film);
    }
}