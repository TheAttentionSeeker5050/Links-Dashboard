using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebAppProject3.Data; // Replace with your actual data context namespace
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    
    // If server is development use use DefaultConnection string
    // else use the connection string called ProductionConnectionString
    if (builder.Environment.IsDevelopment() == false)
    {
        Console.WriteLine("Production environment detected");
        var configuration = builder.Configuration.GetConnectionString("ProductionConnectionString");
        Console.WriteLine("Production connection string: " + configuration);
        options.UseMySql(configuration, ServerVersion.AutoDetect(configuration));
    } else {
        Console.WriteLine("Development environment detected");
        var configuration = builder.Configuration.GetConnectionString("DefaultConnection");
        Console.WriteLine("Development connection string: " + configuration);
        options.UseMySql(configuration, ServerVersion.AutoDetect(configuration));
    }
    
});

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // The login view path
        options.AccessDeniedPath = "/access-denied"; // The access denied view path
        // Set session timeout to 20 minutes
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

// set up forwarding headers to allow proxy redirection
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("64.225.57.224"));
});

// add session support
builder.Services.AddSession();

var app = builder.Build();

// set headers to allow proxy redirection 
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor |  ForwardedHeaders.XForwardedProto
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
/* app.UseHttpsRedirection();*/
}

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configure session middleware
app.UseSession();

app.UseAuthentication(); // Use authentication middleware
app.UseAuthorization(); // Use authorization middleware

// map server ip address to allow proxy redirection
app.MapGet("/", () => "64.225.57.224");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
