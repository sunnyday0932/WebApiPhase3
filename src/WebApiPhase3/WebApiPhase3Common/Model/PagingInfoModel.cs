namespace WebApiPhase3Common.Model
{
    public class PagingInfoModel
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalCount { get; set; }

        public string OrderColumName { get; set; }

        public bool Descending { get; set; }
    }
}
