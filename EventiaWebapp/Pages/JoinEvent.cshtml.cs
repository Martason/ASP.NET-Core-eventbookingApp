using System.Diagnostics.Tracing;
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
        public bool evetAlreadyBooked { set; get; }

        public void OnGet(int eventId)
        {
            var attendee = _eventsHandler.GetAttendees().FirstOrDefault();
            var attendesEventIdList = _eventsHandler.GetEventList(attendee.Id).Select(e => e.Id).ToList();

            if (attendesEventIdList.Contains(eventId)) evetAlreadyBooked = true;

            Evt = _eventsHandler.GetEventList().Find(e => e.Id == eventId);
        }

        public IActionResult OnPost(int eventId)
        {
            
            if (_eventsHandler.ConfirmBooking(eventId))
            {
                return RedirectToPage("ConfirmedBooking", new { eventId });
            }

            return NotFound("Something went wrong");
        }
    }

}
