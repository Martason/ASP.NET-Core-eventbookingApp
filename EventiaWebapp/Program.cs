#region Fas 1 - konfigurering

using EventiaWebapp.Models;
using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


//builder.Services finns i b�de razor och mvp men anv�nder olika metoder
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContextFactory<EpicEventsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EpicEventsContext")));
builder.Services.AddScoped<EventsHandler>(); //service registrerad, med i systemet och jag kan plocka fram det i mitt program.
builder.Services.AddSingleton<DatabaseHandler>();


//TODO fr�ga. Varf�r m�ste jag registrera min DatabaseHandler som en Singelton?
/*
 * You registered the XXXXXXX as a scoped service, in the Startup class.
 * This means that you can not inject it as a constructor parameter in Middleware because
 * only Singleton services can be resolved by constructor injection in Middleware.
 * You should move the dependency to the Invoke method like this:
 */

#endregion


#region Fas 2 - middleware pipelining 

var app = builder.Build();

var remove = app.Services.GetService<DatabaseHandler>();

remove.Recreate();
remove.SeedTestData();

app.UseRouting();

//Mappning


//Mest generella routen sist, 

//MyEvents
app.MapControllerRoute(
    name: "Events",
    pattern: "myEvents/{id:int?}",
    defaults: new { controller = "Events", action = "MyEvents" }
);

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

//specifick f�r Razor pages
app.MapRazorPages();

//MatGet s�tter route (pathname fr�n js) och vilken endpoint som ska n�s genom att s�kv�gen anv�nds i url:n

//app.MapGet("/", () => "Under construction");

#endregion

#region Fas 3 - server 


app.Run();

#endregion