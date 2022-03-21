using EventiaWebapp.Models;
using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventiaWebapp.Controllers
{
    public class EventsController : Controller
    {
        //The constructor uses Dependency Injection to inject the database context (MvcMovieContext) into the controller.
        //The database context is used in each of the CRUD methods in the controller.


        public IActionResult Index()
        {
            return View("Index");
        }
        
    }
}
