using System;
using System.Collections.Generic;

namespace VideoClub.Infrastructure.Models
{
    public class PaginationModel<T>
    {
        public List<T> CurrentPageItems { get; set; }

        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }

        public PaginationModel()
        {
            CurrentPageItems = new List<T>();
        }

        public PaginationModel(List<T> currentPageItems)
        {
            CurrentPageItems = currentPageItems;
        }

        public PaginationModel(List<T> currentPageItems, int currentPage, int itemsPerPage,
            int totalItems)
        {
            CurrentPageItems = currentPageItems;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
        }

        public int TotalPages()
        {
            return Convert.ToInt32(Math.Ceiling(TotalItems / (double)ItemsPerPage));
        }
    }
}