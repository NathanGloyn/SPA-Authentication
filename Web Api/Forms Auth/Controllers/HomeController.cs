using System.Web.Mvc;

namespace WebApi_FormsAuth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
