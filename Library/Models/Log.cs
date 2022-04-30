namespace Library.Models
{
    public enum RequestTypes
    {
        Create,
        Read,
        Update,
        Delete
    }
    public class Log
    {
        public string Message { get; set; }
        public RequestTypes type { get; set; }
    }
}