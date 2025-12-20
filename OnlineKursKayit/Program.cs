using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineKursKayit.Data;
using OnlineKursKayit.Models;
using OnlineKursKayit.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ICourseService, CourseService>();


// Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// DbContext (SQLite)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Identity (ApplicationUser + Roles)
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false; // kolay olsun diye
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<OnlineKursKayit.Services.ICategoryService, OnlineKursKayit.Services.CategoryService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// HTTP pipeline
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ bunlar şart: Authentication sonra Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// ✅ DB migration + seed (roller + admin)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

await SeedData.EnsureSeedAsync(app.Services);

app.Run();
