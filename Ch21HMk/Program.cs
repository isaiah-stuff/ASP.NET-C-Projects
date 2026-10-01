using Ch21HMk.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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
