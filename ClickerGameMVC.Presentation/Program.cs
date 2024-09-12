using ClickerGameMVC.Business.Abstract;
using ClickerGameMVC.Business.Concrete;
using ClickerGameMVC.Data;
using ClickerGameMVC.DataAccess.Repositories;
using ClickerGameMVC.Models;
using ClickerGameMVC.Presentation.Controllers;
using ClickerGameMVC.Service.Abstracts;
using ClickerGameMVC.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IRepository<User>, EFRepository<User>>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserBusiness, UserBusiness>();
builder.Services.AddScoped<UserController>();

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

app.MapRazorPages();


app.Run();


/*
 
 */