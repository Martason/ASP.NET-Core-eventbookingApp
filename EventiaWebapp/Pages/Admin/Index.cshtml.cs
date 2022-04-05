using EventiaWebapp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly UserManager<EventiaUser> _userManager;

        public IndexModel(UserManager<EventiaUser> userManager)
        {
            _userManager = userManager;
        }
        public List<EventiaUser> OrganizersAplications { get; set; }
        public void OnGet()
        {
        }
    }
}
