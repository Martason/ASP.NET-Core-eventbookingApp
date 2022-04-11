using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    [Authorize]
    public class ConfirmedBookingModel : PageModel
    {
        private readonly EventsHandler _eventsHandler;
        private readonly UserManager<Models.EventiaUser> _userManager;

        public ConfirmedBookingModel(UserManager<Models.EventiaUser> userManager, EventsHandler eventsHandler)
        {
            _userManager = userManager;
            _eventsHandler = eventsHandler;
        }

        public Event Evt { get; set; }
        public Models.EventiaUser logedInUser { get; set; }

        public void OnGet(int eventId)
        {
            Evt = _eventsHandler.GetEventList().Find(e => e.Id == eventId);
            logedInUser = _eventsHandler.getAttende(_userManager.GetUserId(User));
        }
    }
}
