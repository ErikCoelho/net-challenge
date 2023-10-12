using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress.Contracts;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;
    public Handler(IRepository repository)
        => _repository = repository;

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate Request
        try
        {
            var response = Specification.Validate(request);
            if (!response.IsValid)
                return new Response("Invalid request.", 400, response.Notifications);
        }
        catch
        {
            return new Response("Unable to validate request.", 500);
        }
        #endregion

        #region Get Address
        Address? address;
        try
        {
            address = await _repository.GetAddressByIdAsync(request.Id, cancellationToken);
            if (address == null)
                return new Response("Address not found", 404);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Update Address
        try
        {
            UpdateAddress(address, request.Id, request.UpdatedCity, request.UpdatedState);
        }
        catch
        {
            return new Response("Failed to update address.", 400);
        }
        #endregion

        #region Persist Data
        try
        {
            await _repository.SaveAsync(address, cancellationToken);
        }
        catch
        {
            return new Response("Failed in data persistence.", 500);
        }
        #endregion

        #region Response
        return new Response("Address updated successfully.", new ResponseData(address.Id, address.City, address.State));
        #endregion
    }

    private void UpdateAddress(Address address, int updatedId, string updatedCity, string updatedState)
    {
        address.UpdateCity(updatedCity);
        address.UpdateState(updatedState);
        address.UpdateId(updatedId);
    }
}
