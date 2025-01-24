using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("DataBase")!);
}).UseLightweightSessions();
builder.Services.AddCarter();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapCarter();
app.Run();
