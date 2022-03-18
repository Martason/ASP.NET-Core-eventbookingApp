#region Fas 1 - konfigurering

using EventiaWebapp.Models;
using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;


//Dependency Injection container
//TODO fr�ga. I datalaggring s� anv�nder vi ingen builder. Utan vi k�rde services = new ServiceCollection

var builder = WebApplication.CreateBuilder(args);


//builder.Services finns i b�de razor och mvp men anv�nder olika metoder
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<EventsHandler>(); //service registrerad, med i systemet och jag kan plocka fram det i mitt program.
builder.Services.AddDbContext<EpicEventsContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("EpicEventsContext")));


#endregion


#region Fas 2 - middleware pipelining 

var app = builder.Build();

//Dependecy are registred in containers, and the container in asp.net core is IServiceProvider
//TODO kan jag l�gga till och registrera den h�r servicen d�r uppe ist�llet? 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedTestData.Initialize(services);
}

//standard i razor och mvp. Tittar efter
app.UseRouting();

//Mappning


//Mest generella routen sist, 

//MyEvents
app.MapControllerRoute(
    name: "Events",
    pattern: "myEvents/{id:int?}",
    defaults: new { controller = "Events", action = "MyEvents" }
);

//JoinEvent
app.MapControllerRoute(
    name: "JoinEvents",
    pattern: "JoinEvent/{id:int?}",
    defaults: new { controller = "Events", action = "JoinEvent" }
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