using EventiaWebapp.Models;
using EventiaWebapp.Services;
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
        public Models.EventiaUser user { get; set; }

        public void OnGet()
        {
            user = _eventsHandler.GetAttendees().FirstOrDefault();
            AttendesEventList = _eventsHandler.GetEventList(user.Id);
        }
    }
}