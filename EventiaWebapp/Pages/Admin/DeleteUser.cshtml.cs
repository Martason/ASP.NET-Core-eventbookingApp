using System.ComponentModel.DataAnnotations;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.Admin
{
    public class DeleteUserModel : PageModel
    {
        private readonly UserManager<Models.EventiaUser> _userManager;
        private readonly EventiaUserHandler _userHandler;

        public DeleteUserModel(UserManager<Models.EventiaUser> userManager, EventiaUserHandler userHandler)
        {
            _userManager = userManager;
            _userHandler = userHandler;
        }

        [BindProperty]
        public Models.EventiaUser UserToHandle { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }


        public async Task OnGet(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            UserToHandle = await _userHandler.GetEventiaUser(user);

        }

        public async Task<IActionResult> OnPostAsync()
        {

            var logedInAdmin = await _userManager.GetUserAsync(User);
            if (logedInAdmin == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var requirePassword = await _userManager.HasPasswordAsync(logedInAdmin);
            if (requirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(logedInAdmin, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            var result = await _userManager.DeleteAsync(UserToHandle);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user.");
            }

            return Redirect("~/");
        }
    }
}
