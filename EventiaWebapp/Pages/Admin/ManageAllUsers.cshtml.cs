using EventiaWebapp.Models;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ManageUsersModel : PageModel
    {
        private readonly EventiaUserHandler _userHandler;

        public ManageUsersModel(EventiaUserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        public List<Models.EventiaUser> AllEventiaUsers { get; set; }
        public async Task OnGet()

        {
            AllEventiaUsers = _userHandler.GetAllUsers();
        }

        public async Task<IActionResult> OnPost(string userId)
        {
          
            return RedirectToPage("./HandleUser", new { userId });
        }


    }
}
