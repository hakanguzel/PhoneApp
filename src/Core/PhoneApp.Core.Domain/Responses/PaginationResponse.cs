namespace PhoneApp.Core.Domain.Responses
{
    public class PaginationResponse
    {
        public PaginationResponse() { }
        public PaginationResponse(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
            TotalPage = 1;
            TotalRecords = 0;
        }
        public PaginationResponse(int page, int pageSize, int totalPage, int totalRecords)
        {
            Page = page;
            PageSize = pageSize;
            TotalPage = totalPage;
            TotalRecords = totalRecords;
        }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public int TotalRecords { get; set; }
    }
}
