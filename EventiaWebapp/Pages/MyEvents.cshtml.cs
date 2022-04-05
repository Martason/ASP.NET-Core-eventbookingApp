using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    [Authorize]
    public class MyEventsModel : PageModel
    {
      
        private readonly EventsHandler _eventsHandler;
        private readonly UserManager<EventiaUser> _userManager;

        public MyEventsModel(EventsHandler eventsHandler, UserManager<EventiaUser> userManager)
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
    }
}