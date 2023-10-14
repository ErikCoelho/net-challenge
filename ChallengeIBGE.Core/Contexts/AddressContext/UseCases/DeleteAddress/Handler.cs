using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress.Contracts;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IRepository _repository;

    public Handler(IRepository repository)
        => _repository = repository;
    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Validate request
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
            if(address == null)
                return new Response("Address not found.", 404);
        }
        catch
        {
            return new Response("Unable to retrieve address.", 500);
        }
        #endregion

        #region Delete address
        try
        {
            if(address != null)
            {
                await _repository.DeleteAddressAsync(address, cancellationToken);
            }
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 500);
        }
        #endregion

        #region Response
        return new Response("Address deleted successfully.", new ResponseData(request.Id));
        #endregion
    }
}
