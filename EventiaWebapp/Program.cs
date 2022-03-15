#region Fas 1 - konfigurering

using EventiaWebapp.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services finns i både razor och mvp men använder olika metoder
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<EventsHandler>(); //service registrerad, med i systemet och jag kan plocka fram det i mitt program.

#endregion


#region Fas 2 - middleware pipelining 

var app = builder.Build();

//standard i razor och mvp
app.UseRouting();

//Mappning


//Mest generella routen sist, 

//Events//MyEvents (Booked?)
app.MapControllerRoute(
    name: "Events",
    pattern: "myEvents/{id:int?}",
    defaults: new { controller = "Events", action = "MyEvents" }
);

//Events//AllEvents (Join?)
app.MapControllerRoute(
    name: "Events",
    pattern: "AllEvents/{date:datetime?}",
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