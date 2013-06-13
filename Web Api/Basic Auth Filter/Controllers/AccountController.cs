using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_BasicAuth_Filter.Controllers
{
    public class AccountController : ApiController
    {
        [AllowAnonymous]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}