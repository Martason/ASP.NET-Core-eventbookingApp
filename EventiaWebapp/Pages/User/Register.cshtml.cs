using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages.User
{
    public class RegisterModel : PageModel
    {
        private readonly UserHandler _userHandler;

        public RegisterModel(UserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [BindProperty]
        public Models.EventiaUser user { set; get; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (_userHandler.RegisterNewUser(user.Username, user.Password, user.Email) != null)
            {
                return RedirectToPage("/User/RegisterSuccess");
            }

            return RedirectToPage("/Error");

        }



    }
}
