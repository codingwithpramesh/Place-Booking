using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Booking.Data;
using BusinessLogicLayer;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddNotyf(config => {
//    config.DurationInSeconds = 10;
//    config.IsDismissable = true;
//    config.Position = NotyfPosition.BottomRight; 
//});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddScoped<IBookingPlaceService, BookingPlaceService>();
builder.Services.AddScoped<IPlacesService, PlacesService>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IHostService, HostService>();
builder.Services.AddScoped<IPostService, PostService>();


//logging

using (var log = new LoggerConfiguration()
    .WriteTo.File("E:\\Apilog.log", rollingInterval:RollingInterval.Day)
    .CreateLogger())
{

    builder.Logging.AddSerilog(log);
    /*log.Information("This is an informational message.");
    log.Warning("This is a warning for testing purposes.");*/
 }

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.SlidingExpiration = true;
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Forbidden";
});

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
};


//seriog 

/*var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
//builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);*/

//end
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCookiePolicy(cookiePolicyOptions);

app.UseHttpsRedirection();
app.UseStaticFiles();

//app.UseNotyf();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
