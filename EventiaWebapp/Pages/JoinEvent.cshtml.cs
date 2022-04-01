using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly Services.EventsHandler _eventsHandler;
        private readonly UserManager<EventiaUser> _userManager;

        public JoinEventModel(Services.EventsHandler eventsHandler, UserManager<EventiaUser> userManager)
        {
            _eventsHandler = eventsHandler;
            _userManager = userManager;
        }

        [BindProperty] public Event Evt { get; set; }
        public bool EvetAlreadyBooked { set; get; }


        public void OnGet(int eventId)
        {
            var attendee = _eventsHandler.GetAttendees().FirstOrDefault();
            var attendesEventIdList = _eventsHandler.GetEventList(attendee.Id).Select(e => e.Id).ToList();

            if (attendesEventIdList.Contains(eventId)) EvetAlreadyBooked = true;

            Evt = _eventsHandler.GetEventList().Find(e => e.Id == eventId);
        }

        public IActionResult OnPost(int eventId)
        {
            var AttendeeId = _userManager.GetUserId(User);

            if (_eventsHandler.ConfirmBooking(eventId, AttendeeId))
            {
                return RedirectToPage("ConfirmedBooking", new {eventId});
            }

            return NotFound("Something went wrong");
        }
    }
}