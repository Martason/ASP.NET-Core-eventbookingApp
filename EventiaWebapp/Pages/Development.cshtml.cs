using EventiaWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventiaWebapp.Pages
{
    public class DevelopmentModel : PageModel
    {
        private readonly DatabaseHandler _databaseHandler;
        private readonly IWebHostEnvironment _environment;


        public DevelopmentModel(DatabaseHandler databaseHandler, IWebHostEnvironment environment)
        {
            _databaseHandler = databaseHandler;
            _environment = environment;
        }
        public IActionResult OnGet()
        {
            if (_environment.IsProduction()) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (_environment.IsProduction()) return NotFound();

            await _databaseHandler.RecreateAndSeed();
            return Page();
        }
    }
}
