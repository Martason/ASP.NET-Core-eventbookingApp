using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class OrganizerRequestsModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;
        private readonly UserManager<EventiaUser> _userManager;

        public OrganizerRequestsModel(EventiaUserHandler userHandler, UserManager<EventiaUser> userManager)
        {
            _userHandler = userHandler;
            _userManager = userManager;
        }
        public List<OrganizerApplication> OrganizerApplication { get; set; }

        public void OnGet()
        {
            OrganizerApplication = _userHandler.GetSeeksOrganizers();
        }
        public async Task<IActionResult> OnPost(string applicantId)
        {
            var logedInAdmin = await _userManager.GetUserAsync(User);

            if (await _userHandler.ApproveForOrganizerRole(applicantId, logedInAdmin))
            {
                return RedirectToPage("./Confirmation", new { applicantId });
            }

            return NotFound("Something went wrong");
        }
    }
}
