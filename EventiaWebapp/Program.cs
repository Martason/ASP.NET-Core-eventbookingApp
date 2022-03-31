#region Fas 1 - konfigurering

using EventiaWebapp.Services;
using EventiaWebapp.Services.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<EpicEventsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EpicEventsContext")));
builder.Services.AddAuthentication("AuktoriseringsCookie").AddCookie("AuktoriseringsCookie", options =>
{
    options.Cookie.Name = "AuktoriseringsCookie";
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OrganizerAccess",
        policy => policy.RequireClaim("Role", "Organizer"));
    options.AddPolicy("OrganizerAccess",
        policy => policy.RequireClaim("Role", "Admin"));
});

builder.Services.AddScoped<EventsHandler>();
builder.Services.AddScoped<DatabaseHandler>();
builder.Services.AddScoped<UserHandler>();
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
        await database.RecreateAndSeed();
        //await database.CreateAndSeedTestDataIfNotExist();
        app.UseDeveloperExceptionPage();
    }
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();//Det är här jag tittar på coocken.
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller}/{action=Index}");

app.MapRazorPages();

#endregion

#region Fas 3 - server

app.Run();

#endregion