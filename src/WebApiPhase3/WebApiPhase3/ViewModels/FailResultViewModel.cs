namespace WebApiPhase3.ViewModels
{
    public class FailResultViewModel
    {
        public string Method { get; set; }

        public string Status { get; set; }

        public FailInforMation Error { get; set; }
    }

    public class FailInforMation
    {
        public string Domain { get; set; }

        public int ErrorCode { get; set; }

        public string Message { get; set; }
    }
}
