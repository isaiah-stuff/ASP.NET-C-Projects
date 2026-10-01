using SportsPlay.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Keep both of the following transient services. They demonstrate
// the use of two services implemented via a single interface.
// Uncomment them out one at a time to demonstrate that they both
// work via the single interface.

// Use the NetMail email service.
//unsecure
// builder.Services.AddTransient<IEmailService, EmailServiceNetMail>();

// Use the MailKit email service.
//best use
builder.Services.AddTransient<IEmailService, EmailServiceMailKit>();

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
