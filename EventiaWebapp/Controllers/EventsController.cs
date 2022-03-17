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

        private readonly EpicEventsContext _context;
        private readonly EventsHandler _eventsHandler;


        public EventsController(EventsHandler eventsHandler)
        {
            //_context = context;
            _eventsHandler = eventsHandler;
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult MyEvents(Attendee? attendeeId)
        {
            if (attendeeId == null)
            {
                return NotFound();
            }

            return View("MyEvents", attendeeId);
        }
        /*
         * The id parameter is generally passed as route data. For example, https://localhost:5001/Events/JoinEvent/1 sets:

                The controller to the Event controller, the first URL segment.
                The action to joinEvent, the second URL segment.
                The id to 1, the last URL segment.
                The id can be passed in with a query string, as in the following example:https://localhost:5001/Events/JoinEvent?id=1

            The id parameter is defined as a nullable type (int?) in cases when the id value isn't provided.
            A lambda expression is passed in to the FirstOrDefaultAsync method to select movie entities that match the route data or query string value.
         */

        public IActionResult JoinEvent(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var evt = await _context.Events.FirstOrDefaultAsync(evt => evt.Id == id);
            var evt = _eventsHandler.EventsList.FirstOrDefault(e => e.Id == id);
            
            if (evt == null)
            {
                return NotFound();
            }
            return View("JoinEvent", evt);
        }

        public IActionResult Confirmation(Event evt, Attendee attendee)
        {
            return View("Confirmation", attendee);
        }

    }
}
