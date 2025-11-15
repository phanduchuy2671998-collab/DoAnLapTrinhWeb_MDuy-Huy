using DoAnLapTrinhWebBanThucAnNhanh.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add MVC
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<FastFoodDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebAppDoAnLTW")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

Console.WriteLine(">>> Connection string: " +
    builder.Configuration.GetConnectionString("WebAppDoAnLTW"));

app.Run();
