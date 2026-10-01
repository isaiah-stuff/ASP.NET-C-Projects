using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Chapter23.Models;

var builder = WebApplication.CreateBuilder(args);

//add services to the container API
builder.Services.AddRazorPages();
builder.Services.AddSession();

builder.Services.AddDbContext<SportsPlayContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SportsPlayConnection")));

// Register the named HttpClients so the application can instantiate
// HttpClient objects via dependency injection

string strApiKey = Environment.GetEnvironmentVariable(ApiKey);

builder.Services.AddHttpClient("SportsPlayClientcustomerService",
    SPCCS =>
    {
        SPCCS.DefaultRequestHeaders.Authorization = new
            AuthenticationHeaderValue("Bearer", strApiKey);
    });

builder.Services.AddHttpClient("SportsPlayClienthumanResources",
    SPCHR =>
    {
        SPCHR.DefaultRequestHeaders.Authorization = new
            AuthenticationHeaderValue("Bearer", strApiKey);
        SPCHR.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
    });



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
