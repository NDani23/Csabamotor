using Csabamotor.Web.Models;
using Csabamotor.Web.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<CsabamotorDBContext>(options =>
{
    IConfigurationRoot configuration = builder.Configuration;

    // Use MSSQL database: need Microsoft.EntityFrameworkCore.SqlServer package for this
    options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));

    // Alternatively use Sqlite database: need Microsoft.EntityFrameworkCore.Sqlite package for this
    //options.UseSqlite(configuration.GetConnectionString("SqliteConnection"));

    // Use lazy loading (don't forget the virtual keyword on the navigational properties also)
    options.UseLazyLoadingProxies();
});

builder.Services.AddTransient<ICsabamotorService, CsabamotorService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Get an instance of the database context and run DbInitializer
// Creating a new service scope is required, because TodoListDbContext is registered as a scoped service
using (var serviceScope = app.Services.CreateScope())
using (var context = serviceScope.ServiceProvider.GetRequiredService<CsabamotorDBContext>())
{
    //string imageSource = app.Configuration.GetValue<string>("ImageSource");
    string imageSource = app.Configuration.GetValue<string>("ImageSource");
    DbInitializer.Initialize(context, imageSource);
}

app.Run();


