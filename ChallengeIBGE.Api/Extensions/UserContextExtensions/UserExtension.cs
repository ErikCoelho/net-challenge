namespace ChallengeIBGE.Api.Extensions.UserContextExtensions;

using MediatR;
using Microsoft.AspNetCore.Mvc;

public static class UserExtension
{
    public static void AddUserContext(this WebApplicationBuilder builder)
    {
        #region Authenticate
        builder.Services.AddTransient<
            Core.Contexts.UserContext.UseCases.Authenticate.Contracts.IRepository,
            Infra.Contexts.UserContext.UseCases.Authenticate.Repository>();
        #endregion

        #region CreateUser
        builder.Services.AddTransient<
            Core.Contexts.UserContext.UseCases.CreateUser.Contracts.IRepository,
            Infra.Contexts.UserContext.UseCases.Create.Repository>();
        #endregion

        #region DeleteUser
        builder.Services.AddTransient<
            Core.Contexts.UserContext.UseCases.DeleteUser.Contracts.IRepository,
            Infra.Contexts.UserContext.UseCases.Delete.Repository>();
        #endregion

        #region SearchUser
        builder.Services.AddTransient<
            Core.Contexts.UserContext.UseCases.SearchUser.Contracts.IRepository,
            Infra.Contexts.UserContext.UseCases.SearchUser.Repository>();
        #endregion

        #region UpdateUser
        builder.Services.AddTransient<
            Core.Contexts.UserContext.UseCases.UpdateUser.Contracts.IRepository,
            Infra.Contexts.UserContext.UseCases.Update.Repository>();
        #endregion
    }
    
    public static void MapUserEndpoints(this WebApplication app)
    {
        #region Authenticate
        app.MapPost("api/v1/user/authenticate", async (
            [FromBody] Core.Contexts.UserContext.UseCases.Authenticate.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.Authenticate.Request,
                Core.Contexts.UserContext.UseCases.Authenticate.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.Data is null)
                return Results.Json(result, statusCode: 500);

            result.Data.Token = JwtExtension.Generate(result.Data);
            return Results.Ok(result);
        });
        #endregion

        #region CreateUser
        app.MapPost("api/v1/user/create", async (
            [FromBody] Core.Contexts.UserContext.UseCases.CreateUser.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.CreateUser.Request,
                Core.Contexts.UserContext.UseCases.CreateUser.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/user/create/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region DeleteUser
        app.MapDelete("api/v1/user/delete", async (
            [FromBody] Core.Contexts.UserContext.UseCases.DeleteUser.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.DeleteUser.Request,
                Core.Contexts.UserContext.UseCases.DeleteUser.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok("User deleted successfully.")
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region SearchUser
        app.MapGet("api/v1/user/search/{id}", async (
            [FromRoute] Guid id,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.SearchUser.Request,
                Core.Contexts.UserContext.UseCases.SearchUser.Response> handler) =>
        {
            var request = new Core.Contexts.UserContext.UseCases.SearchUser.Request(id);
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
            
        });
        #endregion

        #region UpdateUser
        app.MapPut("api/v1/user/update", async (
            [FromBody] Core.Contexts.UserContext.UseCases.UpdateUser.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.UpdateUser.Request,
                Core.Contexts.UserContext.UseCases.UpdateUser.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
