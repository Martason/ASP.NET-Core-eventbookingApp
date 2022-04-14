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
    }

    if (app.Environment.IsDevelopment())
    {
        await database.Recreate();
        await database.SeedTestData();
        //await database.RecreateAndSeed();
       // await database.CreateAndSeedTestDataIfNotExist();
        app.UseDeveloperExceptionPage();
    }

    if (app.Environment.IsProduction())
    {
        await database.Migrate();
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
 * SpotsLeft(), see hur många platser varje event har kvar
 */

//TODO funktion
/*
 * Städa upp kod
 * Fixa render TopOfHead på admin sidan...
 * Fixa Efter man blivit en oganizer så borde det finnas en sida för att lägga till info.
 * Kanske kan göras i kombination med att man ansöker? 
 
 */
//TODO Style
/*
 * Fixa dropdownmeny för my account
 * Fixa admin ManageAllUser sidan så listor visas per role väljs via dropdown meny. Alt är sorterade
 * Fixa så sidan funkar lite bättre för web. mediaQueary?
 * Fixa fonten? Fetstil ser inte bra ut
 */
//TODO felhantera!
// 1. OrganizerAccountApplication()

//TODO Övrigt
/*
 * Läs på om migration, föreläsning 11/4
 * Lägg upp på Azure föreläsning 11/4
 */
