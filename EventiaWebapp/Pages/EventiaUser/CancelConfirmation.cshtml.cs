using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.EventiaUser
{
    [Authorize(Roles = "User")]
    public class CancelConfirmationModel : PageModel
    {

        private readonly EventsHandler _eventsHandler;
        private readonly UserManager<Models.EventiaUser> _userManager;

        public CancelConfirmationModel(EventsHandler eventsHandler, UserManager<Models.EventiaUser> userManager)
        {
            _eventsHandler = eventsHandler;
            _userManager = userManager;
        }

        public Event CancelEvent { set; get; }
        public Models.EventiaUser LogedInUser { set; get; }

        public async Task OnGet(int eventId)
        {

            CancelEvent = await _eventsHandler.GetEvent(eventId);
            LogedInUser = await _userManager.GetUserAsync(User);

        }
    }
}
