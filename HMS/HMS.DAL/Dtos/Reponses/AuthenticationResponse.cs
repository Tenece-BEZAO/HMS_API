
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
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public string? Message { get; set; }
    }
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Token { get; set; }
        public bool Is2StepVerificationRequired { get; set; }
        public string? Provider { get; set; }
    }

}
