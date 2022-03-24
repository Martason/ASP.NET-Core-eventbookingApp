using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class MyEventsModel : PageModel
    {
        private readonly Services.EventsHandler _eventsHandler;

        public MyEventsModel(EventsHandler eventsHandler)
        {
            _eventsHandler = eventsHandler;
        }
        public List<Event> AttendesEventList { get; set; }
        public Attendee Attendee { get; set; }

        public void OnGet()
        {
            Attendee = _eventsHandler.GetAttendees().FirstOrDefault();
            AttendesEventList = _eventsHandler.GetEventList(Attendee.Id);
        }
    }
}
