#region Fas 1 - konfigurering

using EventiaWebapp.Models;
using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


//builder.Services finns i både razor och mvp men använder olika metoder
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EpicEventsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EpicEventsContext")));
builder.Services.AddScoped<EventsHandler>(); //service registrerad, med i systemet och jag kan plocka fram det i mitt program.
//builder.Services.AddTransient<DatabaseHandler>();
builder.Services.AddScoped<DatabaseHandler>();


#endregion

#region Fas 2 - middleware pipelining 

 var app = builder.Build();

//   var databaseHandler = app.Services.GetService<DatabaseHandler>();
//   databaseHandler.Recreate();
//   databaseHandler.SeedTestData();

using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<DatabaseHandler>();
    if (app.Environment.IsProduction())
    {
        await database.CreateIfNotExist();
    }

    if (app.Environment.IsDevelopment())
    {
        await database.CreateAndSeedTestDataIfNotExist();
    }
}
app.UseStaticFiles();
app.UseRouting();

//Mappning


//Mest generella routen sist, 

//AllEvents
app.MapControllerRoute(
    name: "AllEvents",
    pattern: "AllEvents/",
    defaults: new { controller = "Events", action = "Index" }
);

//Login/
app.MapControllerRoute(
    name: "Login",
    pattern: "Login",
    defaults: new { controller = "Login", action = "Index" }
);

// Default route
/////
app.MapControllerRoute(
name: "default",
pattern: "{controller}/{action=Index}"
);

//specifick för Razor pages
app.MapRazorPages();

//MatGet sätter route (pathname från js) och vilken endpoint som ska nås genom att sökvägen används i url:n

//app.MapGet("/", () => "Under construction");

#endregion

#region Fas 3 - server 


app.Run();

#endregion