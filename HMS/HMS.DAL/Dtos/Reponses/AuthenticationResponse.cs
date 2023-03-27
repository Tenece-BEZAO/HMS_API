
namespace HMS.DAL.Dtos.Reponses
{
    public class ResponseStatus
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
