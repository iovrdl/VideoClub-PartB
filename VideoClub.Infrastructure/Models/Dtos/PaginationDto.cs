namespace VideoClub.Infrastructure.Models.Dtos
{
    public class PaginationDto
    {
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }

        public PaginationDto(int? currentPage, int? itemsPerPage)
        {
            if (currentPage == null)
                currentPage = 1;
            if (currentPage < 1)
                currentPage = 1;
            CurrentPage = (int)currentPage;

            if (itemsPerPage == null)
                itemsPerPage = 10;
            if (itemsPerPage < 1)
                itemsPerPage = 10;
            ItemsPerPage = (int)itemsPerPage;
        }

        public int ToSkip()
        {
            return (CurrentPage - 1) * ItemsPerPage;
        }

        public PaginationDto()
        {}
    }
}