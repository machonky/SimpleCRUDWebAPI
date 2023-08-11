using Dapper;
using SimpleCRUDWebAPI.Models;
using SimpleCRUDWebAPI.Queries;
using SimpleCRUDWebAPI.Services;

namespace SimpleCRUDWebAPI.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("users");

        group.MapGet("", async (IDbConnectionFactory connectionFactory) =>
        {
            using var connection = connectionFactory.CreateConnection();
            var users = await connection.QueryAsync<User>(UserQueries.QueryAll);
            return Results.Ok(users);
        });

        group.MapGet("{id}", async (int id, IDbConnectionFactory connectionFactory) =>
        {
            using var connection = connectionFactory.CreateConnection();
            var user = await connection.QuerySingleOrDefaultAsync<User>(UserQueries.QueryById, new { UserId = id });
            return user is not null ? Results.Ok(user) : Results.NotFound();
        });

        group.MapPost("", async (User user, IDbConnectionFactory connectionFactory) => 
        {
            using var connection = connectionFactory.CreateConnection();
            await connection.ExecuteAsync(UserQueries.Insert, user);
            return Results.Ok();
        });

        group.MapPut("{id}", async (int id, User user, IDbConnectionFactory connectionFactory) =>
        {
            user.Id = id;  // Not a good practice - should use a DTO or something
            using var connection = connectionFactory.CreateConnection();
            await connection.ExecuteAsync(UserQueries.Update, user);
            return Results.NoContent();
        });

        group.MapDelete("{id}", async (int id, IDbConnectionFactory connectionFactory) =>
        {
            using var connection = connectionFactory.CreateConnection();
            await connection.ExecuteAsync(UserQueries.Delete, new { UserId = id });
            return Results.NoContent();
        });
    }
}
