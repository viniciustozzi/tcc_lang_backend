using System.Collections.Generic;

namespace TccLangBackend.Api.Auth
{
    public class UserToken
    {
        public int UserId { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}