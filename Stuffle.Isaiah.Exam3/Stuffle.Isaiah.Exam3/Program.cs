using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Exam3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SportsPlayContext>(options => options
    .UseSqlServer(builder.Configuration
    .GetConnectionString("SportsPlayConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
