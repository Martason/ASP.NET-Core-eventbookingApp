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
builder.Services.AddDbContext<EpicEventsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EpicEventsContext")));

builder.Services.AddDefaultIdentity<EventiaUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<EpicEventsContext>();

builder.Services.AddScoped<EventsHandler>();
builder.Services.AddScoped<DatabaseHandler>();
builder.Services.AddScoped<EventiaUserHandler>();
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
 * decline application()
 * cancel booking ()
 * SpotsLeft(), see hur m�nga platser varje event har kvar
 */

//TODO funktion
/*
 * Fixa Usernames
 * St�da upp kod
 * Fixa render TopOfHead p� admin sidan...
 */
//TODO Style
/*
 * Fixa dropdownmeny f�r my account
 * Sixa s� sidan funkar lite b�ttre f�r web. mediaQueary?
 * Fixa fonten? Fetstil ser inte bra ut
 */
//TODO felhantera!
// 1. OrganizerAccountApplication()

//TODO �vrigt
/*
 * L�s p� om migration, f�rel�sning 11/4
 */
