using Layer.Business;
using Layer.DataAccess.Abstract;
using Layer.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<DeviceManager>();
builder.Services.AddScoped<UserManager>();
builder.Services.AddScoped<LocationManager>();
builder.Services.AddScoped<OrganizationManager>();
builder.Services.AddScoped<TypesManager>();

builder.Services.AddDataProtection();
builder.Services.AddDbContext<ContextDb>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("conn"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(ContextDb)).GetName().Name);
    });
});

builder.Services.AddSession();
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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
