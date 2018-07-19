using System.Web.Mvc;

namespace FullStack.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Person");
        }
    }
}