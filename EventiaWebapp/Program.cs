#region Fas 1 - konfigurering

using EventiaWebapp.Models;
using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;


//Dependency Injection container

var builder = WebApplication.CreateBuilder(args);

//builder.Services finns i både razor och mvp men använder olika metoder
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<EventsHandler>(); //service registrerad, med i systemet och jag kan plocka fram det i mitt program.
builder.Services.AddDbContext<EpicEventsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EpicEventsContext")));
#endregion


#region Fas 2 - middleware pipelining 

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

//standard i razor och mvp
app.UseRouting();

//Mappning


//Mest generella routen sist, 

//Events//MyEvents
app.MapControllerRoute(
    name: "Events",
    pattern: "myEvents/{id:int?}",
    defaults: new { controller = "Events", action = "MyEvents" }
);

//Events//JoinEvent
app.MapControllerRoute(
    name: "Events",
    pattern: "JoinEvent/{id:int?}",
    defaults: new { controller = "Events", action = "JoinEvent" }
);

//Events//AllEvents
app.MapControllerRoute(
    name: "Events",
    pattern: "AllEvents/",
    defaults: new { controller = "Events", action = "AllEvents" }
);

//Login/
app.MapControllerRoute(
    name: "Login",
    pattern: "Login",
    defaults: new { controller = "Login", action = "Index" }
);

// Default route
////Events/
app.MapControllerRoute(
name: "default",
pattern: "{controller=Events}/{action=Index}"
);

//specifick för Razor pages
app.MapRazorPages();

//MatGet sätter route (pathname från js) och vilken endpoint som ska nås genom att sökvägen används i url:n

//app.MapGet("/", () => "Under construction");

#endregion

#region Fas 3 - server 


app.Run();

#endregion