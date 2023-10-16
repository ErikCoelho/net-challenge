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
        app.MapPost("api/v1/authenticate", async (
            [FromBody] Core.Contexts.UserContext.UseCases.Authenticate.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.Authenticate.Request,
                Core.Contexts.UserContext.UseCases.Authenticate.Response> handler) =>
        {

        });
        #endregion

        #region CreateUser
        app.MapPost("api/v1/user/create", async (
            [FromBody] Core.Contexts.UserContext.UseCases.CreateUser.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.CreateUser.Request,
                Core.Contexts.UserContext.UseCases.CreateUser.Response> handler) =>
        {

        });
        #endregion

        #region DeleteUser
        app.MapDelete("api/v1/user/delete", async (
            [FromBody] Core.Contexts.UserContext.UseCases.DeleteUser.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.DeleteUser.Request,
                Core.Contexts.UserContext.UseCases.DeleteUser.Response> handler) =>
        {

        });
        #endregion

        #region SearchUser
        app.MapGet("api/v1/user/search", async (
            [FromBody] Core.Contexts.UserContext.UseCases.SearchUser.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.SearchUser.Request,
                Core.Contexts.UserContext.UseCases.SearchUser.Response> handler) =>
        {

        });
        #endregion

        #region UpdateUser
        app.MapPut("api/v1/user/update", async (
            [FromBody] Core.Contexts.UserContext.UseCases.UpdateUser.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.UserContext.UseCases.UpdateUser.Request,
                Core.Contexts.UserContext.UseCases.UpdateUser.Response> handler) =>
        {

        });
        #endregion
    }
}
