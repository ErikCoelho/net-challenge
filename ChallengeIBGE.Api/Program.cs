using ChallengeIBGE.Infra.Data;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

Database.ConnectionString = connectionString!;

app.Run();