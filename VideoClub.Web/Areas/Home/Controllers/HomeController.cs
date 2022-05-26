using System.Web.Mvc;

namespace VideoClub.Web.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}