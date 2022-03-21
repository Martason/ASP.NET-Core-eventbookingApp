using EventiaWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly Services.EventsHandler _eventsHandler;
        public JoinEventModel(Services.EventsHandler eventsHandler)
        {
            _eventsHandler = eventsHandler;
        }

        public Event Evt { get; set; }
        public void OnGet(int eventId)
        {
           Evt = _eventsHandler.GetEventList().Find(e => e.Id == eventId);
        }

        public IActionResult OnPost(int evtId)
        {
             if (_eventsHandler.ConfirmBooking(evtId))
             {
                 return RedirectToPage("ConfirmedBooking", new {eventId = evtId});
                //TODO varför new routeValue? behövs ju inte vid "asp-route-id="@eventList[i].Id"
                //TODO bättre namn än Id och id? evtId? asp-route-evtId=
            }

            return NotFound("404");
        }
    }
}
