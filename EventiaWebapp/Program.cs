#region Fas 1 - konfigurering

using EventiaWebapp.Models;
using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<EventsHandler>();
builder.Services.AddScoped<DatabaseHandler>();
builder.Services.AddScoped<EventiaUserHandler>();
builder.Services.AddScoped<AdminService>();

builder.Services.AddDbContext<EpicEventsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<EventiaUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EpicEventsContext>();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

#endregion

#region Fas 2 - middleware pipelining

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var database = scope.ServiceProvider.GetRequiredService<DatabaseHandler>();
    if (app.Environment.IsProduction())
    {
        await database.CreateIfNotExist();
        await database.Migrate();
    }

    if (app.Environment.IsDevelopment())
    {
        await database.Recreate();
        await database.SeedTestData();
        //await database.RecreateAndSeed();
       // await database.CreateAndSeedTestDataIfNotExist();
        app.UseDeveloperExceptionPage();
    }

}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}");

app.MapRazorPages();

#endregion

#region Fas 3 - server

app.Run();

#endregion

//TODO metoder
/*
 * SpotsLeft(), see hur m�nga platser varje event har kvar
 */

//TODO funktion
/*
 * St�da upp kod
 * Fixa render TopOfHead p� admin sidan...
 * Fixa Efter man blivit en oganizer s� borde det finnas en sida f�r att l�gga till info.
 * Alternativ att det b�r g�ras i kombination med att man ans�ker?
 * Admin b�r kunna ta bort Attendekonton
 
 */
//TODO Style
/*
 * Fixa dropdownmeny f�r my account
 * Fixa admin ManageAllUser sidan s� listor visas per role v�ljs via dropdown meny. Alt �r sorterade
 * Fixa s� sidan funkar lite b�ttre f�r web. mediaQueary?
 * Fixa fonten? Fetstil ser inte bra ut
 */
//TODO felhantera!
// 1. K�nns som att jag inte fokuserat alls p� detta i denna uppgift. 

//TODO �vrigt
/*
 * L�s p� om migration, f�rel�sning 11/4
 * L�gg upp p� Azure f�rel�sning 11/4
 * G� igenom och fixa med variablen namn, k�nns r�rigt just nu
 * Se �ver mina sevices.
 */
