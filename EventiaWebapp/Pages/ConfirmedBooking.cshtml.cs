using EventiaWebapp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class ConfirmedBookingModel : PageModel
    {

        private readonly Services.EventsHandler _eventsHandler;

        public ConfirmedBookingModel(Services.EventsHandler eventsHandler)
        {
            _eventsHandler = eventsHandler;
        }

        public Event Evt { get; set;}
        public Attendee Attendee { get; set;}

        //TODO får inte tag på attendes listan.... ? 

        public void OnGet(int eventId)
        {
            Evt = _eventsHandler.GetEventList().Find(e => e.Id == eventId);
            Attendee = _eventsHandler.GetAttendees().FirstOrDefault();
        }

    }
}
