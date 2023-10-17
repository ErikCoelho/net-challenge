using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeIBGE.Api.Extensions.AddressContext;

public static class AddressExtension
{
    public static void AddAddressContext(this WebApplicationBuilder builder)
    {
        #region CreateAddress
        builder.Services.AddTransient<
            Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts.IRepository,
            Infra.Contexts.AddressContext.UseCases.Create.Repository>();
        #endregion

        #region DeleteAddress
        builder.Services.AddTransient<
            Core.Contexts.AddressContext.UseCases.DeleteAddress.Contracts.IRepository,
            Infra.Contexts.AddressContext.UseCases.Delete.Repository>();
        #endregion

        #region ListAddresses
        builder.Services.AddTransient<
            Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts.IRepository,
            Infra.Contexts.AddressContext.UseCases.List.Repository>();
        #endregion

        #region UpdateAddress
        builder.Services.AddTransient<
            Core.Contexts.AddressContext.UseCases.UpdateAddress.Contracts.IRepository,
            Infra.Contexts.AddressContext.UseCases.Update.Repository>();
        #endregion
    }

    public static void MapAddressEndpoints(this WebApplication app)
    {
        #region CreateAddress
        app.MapPost("api/v1/address/create", async (
            [FromBody] Core.Contexts.AddressContext.UseCases.CreateAddress.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.AddressContext.UseCases.CreateAddress.Request,
                Core.Contexts.AddressContext.UseCases.CreateAddress.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Created($"api/v1/address/create/{result.Data?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region DeleteAddress
        app.MapDelete("api/v1/address/delete", async (
            [FromBody] Core.Contexts.AddressContext.UseCases.DeleteAddress.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.AddressContext.UseCases.DeleteAddress.Request,
                Core.Contexts.AddressContext.UseCases.DeleteAddress.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok("Address deleted successfully.")
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region ListAddresses
        app.MapGet("api/v1/address/search", async (
            [FromQuery] int? id, string? city, string? state,
            [FromServices] IRequestHandler<
                Core.Contexts.AddressContext.UseCases.ListAddresses.Request,
                Core.Contexts.AddressContext.UseCases.ListAddresses.Response> handler) =>
        {
            var request = new Core.Contexts.AddressContext.UseCases.ListAddresses.Request(id, city, state);
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region UpdateAddress
        app.MapPut("api/v1/address/update", async (
            [FromBody] Core.Contexts.AddressContext.UseCases.UpdateAddress.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.AddressContext.UseCases.UpdateAddress.Request,
                Core.Contexts.AddressContext.UseCases.UpdateAddress.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());
            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion
    }
}
