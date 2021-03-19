namespace WebApiPhase3.Parameters
{
    public class PagingParameter
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalCount { get; set; }

        public string OrderColumName { get; set; }

        public bool Descending { get; set; }
    }
}
