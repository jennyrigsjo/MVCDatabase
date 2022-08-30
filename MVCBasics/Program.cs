using System.Globalization;
using Microsoft.EntityFrameworkCore;
using MVCBasics.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); //Register database context as a service to enable dependency injection
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();


// enforce use of periods as decimal separator
var cultureInfo = new CultureInfo("en-US"); 
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=About}/{id?}" //Add default pattern to enable linking to pages by referencing controller and action names 
    );

app.MapControllerRoute(
    name: "fevercheck",
    pattern: "fevercheck",
    defaults: new { controller = "Doctor", action = "FeverCheck" }
    );

app.MapControllerRoute(
    name: "guessinggame",
    pattern: "guessinggame",
    defaults: new { controller = "GuessNumber", action = "GuessNumber" }
    );

app.Run();
