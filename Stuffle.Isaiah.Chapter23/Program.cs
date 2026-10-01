using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Chapter23.Models;

var builder = WebApplication.CreateBuilder(args);

//add services to the container
builder.Services.AddRazorPages();
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SportsPlayContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportsPlayConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
