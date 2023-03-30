using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using UBB_Bike_Rental_System.AutoMapper;
using UBB_Bike_Rental_System.DB;
using UBB_Bike_Rental_System.Models;
using UBB_Bike_Rental_System.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MapVehicleDetialViewModelToVehicle),typeof(MapVehicleToVehicleDetialViewModel));
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<InMemoryDbContext>(options => options.UseInMemoryDatabase("UBB_Bike_Rental_System"));
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
