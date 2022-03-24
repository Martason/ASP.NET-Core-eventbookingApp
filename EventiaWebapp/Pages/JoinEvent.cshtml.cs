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
        [BindProperty]
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
                //TODO varför new routeValue? behövs ju inte när jag länkade i html koden på "AllEvents" sidan med "asp-route-id="@eventList[i].Id"
                //TODO känsligt med namnet som inte får vara samma, kan man använda this? 
            }

            return NotFound("404");
        }
    }

}
