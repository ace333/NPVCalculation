namespace CashFlow.Application.Dto
{
    public sealed class PagingInfo
    {
        public PagingInfo(int totalRecords, int limit, int offset)
        {
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling(totalRecords / (double)limit);
        }

        public int TotalRecords { get; }
        public int TotalPages { get; }
    }
}
