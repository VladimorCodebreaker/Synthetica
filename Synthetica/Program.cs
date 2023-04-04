using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Synthetica.Data;
using Synthetica.Data.Cart;
using Synthetica.Data.Services;
using Synthetica.Data.IServices;
using Synthetica.Models;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration String
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDrugService, DrugService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPharmacyService, PharmacyService>();
builder.Services.AddScoped<IProducerService, ProducerService>();
builder.Services.AddScoped<ISubstanceService, SubstanceService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

//Authentication and authorization
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DatabaseContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Drug/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Drug}/{action=Index}/{id?}");

// Initialize Database
DatabaseInitializer.Seed(app);
DatabaseInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();


// Admin Email: admin@gmail.com
// Password:   Coding@1234?

