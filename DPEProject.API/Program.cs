using DPEProject.API.Extensions;

// Configure the HTTP request pipeline.
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    WebRootPath = "Uploads",
    Args = args
});
builder.Services.AddApplicationServices(builder);


var app = builder.Build();
{  
    app.ConfigureApplication();
    app.Run();  
}