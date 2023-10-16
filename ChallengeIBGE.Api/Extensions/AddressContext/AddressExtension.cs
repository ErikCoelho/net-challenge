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

        });
        #endregion

        #region DeleteAddress
        app.MapDelete("api/v1/address/delete", async (
            [FromBody] Core.Contexts.AddressContext.UseCases.DeleteAddress.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.AddressContext.UseCases.DeleteAddress.Request,
                Core.Contexts.AddressContext.UseCases.DeleteAddress.Response> handler) =>
        {

        });
        #endregion

        #region ListAddresses
        app.MapGet("api/v1/address/search", async (
            [FromBody] Core.Contexts.AddressContext.UseCases.ListAddresses.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.AddressContext.UseCases.ListAddresses.Request,
                Core.Contexts.AddressContext.UseCases.ListAddresses.Response> handler) =>
        {

        });
        #endregion

        #region UpdateAddress
        app.MapPut("api/v1/address/update", async (
            [FromBody] Core.Contexts.AddressContext.UseCases.UpdateAddress.Request request,
            [FromServices] IRequestHandler<
                Core.Contexts.AddressContext.UseCases.UpdateAddress.Request,
                Core.Contexts.AddressContext.UseCases.UpdateAddress.Response> handler) =>
        {

        });
        #endregion
    }
}
