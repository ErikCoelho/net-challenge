using ChallengeIBGE.Api.Extensions;
using ChallengeIBGE.Api.Extensions.AddressContext;
using ChallengeIBGE.Api.Extensions.UserContextExtensions;
using ChallengeIBGE.Infra.Data;

#region Builder
var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDatabase();
builder.AddJwtAuthentication();

builder.AddUserContext();
builder.AddAddressContext();

builder.AddMediatr();
builder.AddSwaggerGen();
#endregion

#region App
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapUserEndpoints();
app.MapAddressEndpoints();

var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

Database.ConnectionString = connectionString!;

app.Run();
#endregion
