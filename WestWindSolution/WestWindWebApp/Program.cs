using WestWindWebApp.Components;
using WestWindSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//retrievve the connection string the appsettings
//the connection string will be passed to the class library extension method
//  for use in registering the access to the residered database
var connectionstring = builder.Configuration.GetConnectionString("WWDB");

//setup the registraton of services to be available for use by this web application
//the technique used in this example has the registration encapsulated within the
//  class library extension class
//technically, you could do all the setup within this file
builder.Services.WestWindExtensionServices(options => options.UseSqlServer(connectionstring));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
