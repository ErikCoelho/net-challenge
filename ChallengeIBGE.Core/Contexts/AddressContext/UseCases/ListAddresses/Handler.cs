using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;
using MediatR;
using System.Threading;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses;

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
                return new Response("Request Invalid", 400, response.Notifications);
        }
        catch
        {
            return new Response("Unable to validate request", 500);
        }
        #endregion

        #region List Addresses
        List<Address>? addresses;
        try
        {
            addresses = await GetAddress(request, cancellationToken);
            if (addresses == null)
                return new Response("Address not found.", 404);
        }
        catch (Exception ex)
        {
            return new Response(ex.Message, 400);
        }
        #endregion

        #region Response
        return new Response("", new ResponseData(addresses!));
        #endregion
    }

    public async Task<List<Address>?> GetAddress(Request request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.City))
            return await _repository.GetAddressByCity(request.City, cancellationToken);
        else if (!string.IsNullOrEmpty(request.State))
            return await _repository.GetAddressByState(request.State, cancellationToken);
        else
            return await _repository.GetAddressById(request.Id, cancellationToken);
    }
}
