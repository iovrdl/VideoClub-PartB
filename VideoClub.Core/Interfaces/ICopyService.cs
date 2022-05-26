using VideoClub.Core.Entities;

namespace VideoClub.Core.Interfaces
{
    public interface ICopyService
    {
        Copy GetFirstAvailable(int filmId);
        void Add(Copy copy);
        void Add(int filmId, int totalCopies);
        void UpdateIsAvailable(int copyId, bool isAvailable);
    }
}