using EventiaWebapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EventiaWebapp.Pages
{
    public class JoinEventModel : PageModel
    {
        private readonly Services.EventsHandler _eventsHandler;
        private readonly UserManager<Models.EventiaUser> _userManager;

        public JoinEventModel(Services.EventsHandler eventsHandler, UserManager<Models.EventiaUser> userManager)
        {
            _eventsHandler = eventsHandler;
            _userManager = userManager;
           
        }

        [BindProperty] 
        public Event Evt { get; set; }
        public bool AlreadyBooked { set; get; }


        public void OnGet(int eventId)

        {
            Evt = _eventsHandler.GetEventList().Find(e => e.Id == eventId);

            var logedInUserId = _userManager.GetUserId(User);
            if (logedInUserId != null)
            {
                var attendesEvent = _eventsHandler.GetEventList(logedInUserId);

                var attendesEventIdList = attendesEvent.Select(e => e.Id).ToList();

                if (attendesEventIdList.Contains(eventId)) AlreadyBooked = true;
            }

     

        }

        public IActionResult OnPost(int eventId)
        {
            var logedInUserId = _userManager.GetUserId(User);

            if (_eventsHandler.ConfirmBooking(eventId, logedInUserId))
            {
                return RedirectToPage("/EventiaUser/ConfirmedBooking", new {eventId});
            }

            return NotFound("Something went wrong");
        }
    }
}