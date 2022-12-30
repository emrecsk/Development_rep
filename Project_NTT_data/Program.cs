using Layer.Business;
using Layer.DataAccess.Abstract;
using Layer.DataAccess.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project_NTT_data.Filters;
using Project_NTT_data.MiddleWares;
using System.Configuration;
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
//builder.Services.AddScoped<CheckWhiteList>(); //Bu ise controller veya method seviyesinde yasakli IP adresi belirtmek icin kullaniliyor.

builder.Services.AddDataProtection();//For crypted ID's
builder.Services.Configure<IPList>(builder.Configuration.GetSection("IPList")); //to get the IP's that given access

var constrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("conn"));
constrBuilder.Password = builder.Configuration["Password:SqlPass"];
var connection = constrBuilder.ConnectionString;

builder.Services.AddDbContext<ContextDb>(x =>
{
    x.UseSqlServer(connection, option =>
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
app.UseMiddleware<IPSafeMiddleWare>(); //Butun uygulama icin bunu ekledik. Eger bu listede olmayan bir IP adresinden istek yapilirsa uygulamaya erisilemeyecek. Reference line 21
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
