using Taskadika.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();

// builder.Services.RegisterPostgresDataBase(EnvVars.PostgresConnectionString);

var app = builder.Build();

// custom class with extension methods to register web application middleware services
app.RegisterMiddlewares();

// custom class with extension methods to register .net endpoints/routes
app.RegisterEndpoints();

app.Run();

public partial class Program { }
