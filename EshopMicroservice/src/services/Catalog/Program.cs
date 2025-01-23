using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddCarter();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapCarter();
app.Urls.Add("http://*:8080");
app.Run();
