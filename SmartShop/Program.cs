using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartShop.Data;
using SmartShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("Server = (LocalDb)\\MSSQLLocalDB; D   atabase = aspnet - SmartShop - E02F4E10 - 871C - 4A59 - AFB2 - DC5CC82E4DB6; Trusted_Connection = True; MultipleActiveResultSets = true");
builder.Services.AddDbContext<SmartShopDbContext>(options =>
    options.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=SmartShop;Integrated Security = true;"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<SmartShopDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.PrepDb();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
