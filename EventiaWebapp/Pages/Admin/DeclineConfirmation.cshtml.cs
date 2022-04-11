using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    public class DeclineConfirmationModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;

        public DeclineConfirmationModel(EventiaUserHandler userHandler)
        {
            _userHandler = userHandler;
        }
        public Models.EventiaUser EventiaUser { get; set; }


        public async Task OnGet(string applicantId)
        {
            EventiaUser = await _userHandler.GetEventiaUser(applicantId);
        }
    }
}
