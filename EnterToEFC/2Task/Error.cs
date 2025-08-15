namespace _2Task
{
    public enum StatusCode
    {
        Ok = 200,
        NotFound = 404,
        Server = 500
    }

    public class Error
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }
        public string Request { get; set; }
        public StatusCode Status { get; set; }
    }
}
