using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class OrganizerRequestsModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;

        public OrganizerRequestsModel(EventiaUserHandler userHandler)
        {
            _userHandler = userHandler;
        }
        public List<EventiaUser> UsersSeekingOrganizerRole { get; set; }

        public void OnGet()
        {
            UsersSeekingOrganizerRole = _userHandler.GetSeeksOrganizers();
        }
        public async Task<IActionResult> OnPost(string userId)
        {

            if (await _userHandler.ApproveForOrganizerRole(userId))
            {
                return RedirectToPage("./Confirmation", new { userId });
            }

            return NotFound("Something went wrong");
        }
    }
}
