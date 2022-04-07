using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EventiaWebapp.Areas.Identity.Pages.Account.Manage
{
    public class OrganizerApplicationModel : PageModel
    {

        private readonly EventiaUserHandler _userHandler;
        private readonly UserManager<EventiaUser> _userManager;

        public OrganizerApplicationModel(UserManager<EventiaUser> userManager, EventiaUserHandler userHandler)
        {
            _userManager = userManager;
            _userHandler = userHandler;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var logedInUserId = _userManager.GetUserId(User);

            if (await _userHandler.OrganizerAccountApplication(logedInUserId))
            {
                return RedirectToPage("./ConfirmApplication");
            }

            return NotFound("Something went wrong");
        }
    }
}
