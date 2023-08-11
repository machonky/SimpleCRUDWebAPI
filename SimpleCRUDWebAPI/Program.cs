using Dapper;
using Npgsql;
using SimpleCRUDWebAPI.Endpoints;
using SimpleCRUDWebAPI.Models;
using SimpleCRUDWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnectionFactory>(serviceProvider => 
{ 
    var configuration = serviceProvider.GetService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                            throw new ApplicationException("Missing default connection string");

    return new NpgSqlConnectionFactory(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Postgress is awkward with respect to fieldnames so we can set this flag to operate Dapper with snake-case field names
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

app.MapUserEndpoints();

app.Run();
