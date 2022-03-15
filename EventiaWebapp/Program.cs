#region Fas 1 - konfigurering

using EventiaWebapp.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services finns i b�de razor och mvp men anv�nder olika metoder
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

//specifick f�r Razor pages
app.MapRazorPages();

//MatGet s�tter route (pathname fr�n js) och vilken endpoint som ska n�s genom att s�kv�gen anv�nds i url:n

//app.MapGet("/", () => "Under construction");

#endregion

#region Fas 3 - server 


app.Run();

#endregion