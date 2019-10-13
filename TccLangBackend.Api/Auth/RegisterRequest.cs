namespace TccLangBackend.Api.Auth
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Password { get; set; }
    }
}