using System;

namespace TccLangBackend.Api.Auth
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}