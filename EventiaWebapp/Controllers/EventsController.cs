using Microsoft.AspNetCore.Mvc;

namespace EventiaWebapp.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }
        public IActionResult AllEvents()
        {
            return View("AllEvents");
        }
        public IActionResult MyEvents()
        {
            return View("MyEvents");
        }
    }
}
