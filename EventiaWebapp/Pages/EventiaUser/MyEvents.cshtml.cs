using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    [Authorize]
    public class MyEventsModel : PageModel
    {
      
        private readonly EventsHandler _eventsHandler;
        private readonly UserManager<Models.EventiaUser> _userManager;

        public MyEventsModel(EventsHandler eventsHandler, UserManager<Models.EventiaUser> userManager)
        {
            _eventsHandler = eventsHandler;
            _userManager = userManager;
        }

        public List<Event>? AttendesEventList { get; set; }

        public void OnGet()
        {
            var logedInUserId = _userManager.GetUserId(User);

            if (logedInUserId != null)
            {
                AttendesEventList = _eventsHandler.GetEventList(logedInUserId);
            }
        }

        public IActionResult OnPostCancel(int eventId)
        {
            var logedInUserId = _userManager.GetUserId(User);

            if (_eventsHandler.CancelBooking(eventId, logedInUserId))
            {
                return RedirectToPage("./CancelConfirmation");

            }

            return NotFound("Something went wrong");

        }
    }
}