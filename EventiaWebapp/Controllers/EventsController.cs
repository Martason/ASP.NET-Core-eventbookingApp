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
        public IActionResult MyEvents(int id)
        {
            return View("MyEvents", id);
        }
    }
}
