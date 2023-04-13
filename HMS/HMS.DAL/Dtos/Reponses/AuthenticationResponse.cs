
namespace HMS.DAL.Dtos.Reponses
{
    public class ResponseStatus
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        //public string Token { get; set; }
        //public string UserName { get; set; }
       // public string Role { get; set; }
    }
    // public record ResponseStatus(int StatusCode, string Message, string Token, string UserName, string Role);
    public class RegistrationResult
    {
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }
        public string ConfirmationLink { get; set; }
    }

}
