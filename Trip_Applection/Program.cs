using Trip_Applection.Models;
using Trip_Applection.BL;
using Microsoft.AspNetCore.Identity;
using Trip_Applection.Areas.admin.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TravelsContext>();
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TravelsContext>();
builder.Services.AddScoped<IRepostry<Catogery>, Repository<Catogery>>();
builder.Services.AddScoped<IRepostry<City>, Repository<City>>();
builder.Services.AddScoped<IRepostry<Contry>, Repository<Contry>>();
builder.Services.AddScoped<IRepostry<Trip>, Repository<Trip>>();
builder.Services.AddScoped<IRepostry<Imag>, Repository<Imag>>();
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
app.UseAuthentication();
app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

