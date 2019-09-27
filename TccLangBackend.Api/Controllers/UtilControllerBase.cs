using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace TccLangBackend.Api.Controllers
{
    public class UtilControllerBase : Controller
    {
        protected int UserId => HttpContext.User.Claims
            .Where(x => x.Type == ClaimTypes.Sid)
            .Select(x => int.Parse(x.Value))
            .FirstOrDefault();
    }
}