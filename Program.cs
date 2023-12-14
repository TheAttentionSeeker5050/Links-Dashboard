using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebAppProject3.Data; // Replace with your actual data context namespace
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add Entity Framework Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var configuration = builder.Configuration.GetConnectionString("DefaultConnection");
    
    // If server is development use use DefaultConnection string
    // else use the connection string called ProductionConnectionString
    if (!builder.Environment.IsDevelopment())
    {
        configuration = builder.Configuration.GetConnectionString("ProductionConnectionString");
    }
    
    options.UseMySql(configuration, ServerVersion.AutoDetect(configuration));
});

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Customize the login path
        options.AccessDeniedPath = "/access-denied"; // Customize the access denied path
    });

// add session support
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Configure session middleware
app.UseSession();

app.UseAuthentication(); // Use authentication middleware
app.UseAuthorization(); // Use authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
