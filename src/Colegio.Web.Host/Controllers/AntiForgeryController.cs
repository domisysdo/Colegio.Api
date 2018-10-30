using Microsoft.AspNetCore.Antiforgery;
using Colegio.Controllers;

namespace Colegio.Web.Host.Controllers
{
    public class AntiForgeryController : ColegioControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
