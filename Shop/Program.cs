using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shop.ApplicationServices.Services;
using Shop.Core.Domain;
using Shop.Core.ServiceInterface;
using Shop.Data;
using Shop.Security;
using Shop.SignalRChat.Hubs;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddSignalR();

builder.Services.AddDbContext<ShopContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();
builder.Services.AddScoped<IFileServices, FilesServices>();
builder.Services.AddScoped<IRealEstateServices, RealEstatesServices>();
builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddScoped<IChuckNorrisServices, ChuckNorrisServices>();
builder.Services.AddScoped<ICocktailServices, CocktailServices>();
builder.Services.AddScoped<IAccuWeatherForecastServices, AccuWeatherForecastServices>();
builder.Services.AddScoped<IEmailServices, EmailServices>();

builder.Services.AddRazorPages();
//builder.Services.AddDbContext<ShopContext>(options => 
//options.UseSqlServer(builder.Configuration.GetConnectionString("DafaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3;

    options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";

    options.Lockout.MaxFailedAccessAttempts = 2;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
.AddEntityFrameworkStores<ShopContext>()
.AddDefaultTokenProviders()
.AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation")
.AddDefaultUI();

builder.Services.Configure<DataProtectionTokenProviderOptions>(o => 
o.TokenLifespan = TimeSpan.FromMinutes(5));

builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(o => 
o.TokenLifespan = TimeSpan.FromDays(3));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider

    (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<ChatHub>("/ChatHub/chat");

app.Run();
