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
                //TODO varf�r new routeValue? beh�vs ju inte n�r jag l�nkade i html koden p� "AllEvents" sidan med "asp-route-id="@eventList[i].Id"
                //TODO k�nsligt med namnet som inte f�r vara samma, kan man anv�nda this? 
            }

            return NotFound("404");
        }
    }

}
