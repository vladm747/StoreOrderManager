using System.Text.Json.Serialization.Metadata;

namespace StoreOrderManager.Models
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int PagesCount { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager()
        {
            
        }

        public Pager(int totalItems, int page, int pageSize = 10 )
        {
            int pageCount = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
            int pageIndex = page;
            int startPage = pageIndex - 5; 
            int endPage = pageSize + 20;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > pageCount)
            {
                endPage = pageCount;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }
            
            TotalItems = totalItems;
            PageIndex = pageIndex;
            PageSize = pageSize;
            PagesCount = pageCount;
            StartPage = startPage;
            EndPage = endPage;
        }
    }
}
