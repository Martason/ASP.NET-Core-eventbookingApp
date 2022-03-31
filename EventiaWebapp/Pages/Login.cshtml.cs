using System.Security.Claims;
using EventiaWebapp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserHandler _userHandler;

        public LoginModel(UserHandler userHandler)
        {
            _userHandler = userHandler;
        }

        [BindProperty]
        public Models.EventiaUser user { set; get; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {

            //Veryify the credentials genom att kolla med databasen
            var logedInUser = _userHandler.LoginUser(user.Username, user.Password);

            if(logedInUser  == null) return RedirectToPage("/Error");

            // security context
            // Skapas genom att först göra en lista med olika claims attribut och assigna dem till en ClaimsIdentity
            // ClaimsIdentity kommer av vara typen coockieAuthentication och man namnger dem själva. 
            //TODO använda en konstant då namnet förekommer på flera ställen

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, logedInUser.Email),
                new Claim("Id", logedInUser.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, "AuktoriseringsCookie");
            //The authenticationType parameter. If the authenticationType parameter is null or an empty string, the value of the identity.AuthenticationType (IIdentity.AuthenticationType) property is used.

            //Nu behövs en ClaimsPrincipal, Den kan vara tom men man kan också assigna en primiaryIdentity, i mitt fall identiteten jag precis skapade
            //
            /*
                 * Principal = User
                 * Identity = Driver's License, Passport, Credit Card, Google Account, Facebook Account, RSA SecurID, Finger print, Facial recognition, etc.

                    If you're pulled over by the police, they don't verify you're who you claim to be, based on your driver's license alone. 
                    They also need to see your face. Otherwise you could show anyones driver's license.
                    Hence it makes sense, why authentication can and sometimes should be based on multiple identities. 
                    That's why 1 ClaimsPrincipal can have any number of ClaimsIdentity.
                 */

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            //Nu ska allt detta sparas ner för att användas av browsern som en coocke. HttpContext och SignInAsynch löser det för oss
            //och skapar en coocke som är min claimsPrincipal serialiserad till en krypterad stäng. 

            await HttpContext.SignInAsync("AuktoriseringsCookie", claimsPrincipal);

            var userId = int.Parse(Request.Cookies["AuktoriseringsCookie"]);

            return RedirectToPage("Index");

        }


    }
}
