using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts;
using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress;

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
				return new Response("Invalid request", 400, response.Notifications);
        }
		catch
		{
			return new Response("Unable to validate request", 500);
		}
		#endregion

		#region Create Address
		Address address;
		try
		{
			address = new(request.City, request.State, request.Id);
		}
		catch (Exception ex)
		{
			return new Response(ex.Message, 400);
		}
		#endregion

		#region Verify if already exists
		try
		{
            var exists = await _repository.AnyAsync(request.Id, cancellationToken);
			if (exists)
				return new Response("Address already exists.", 400);
		}
		catch
		{
			return new Response("Failed to verify address", 500);
		}
		#endregion

		#region Persist Data
		try
		{
            await _repository.SaveAsync(address, cancellationToken);
		}
		catch
		{
			return new Response("Failed to persist data", 500);
		}
		#endregion

		#region Response
		return new Response("Address created successfully.", new ResponseData(address.City, address.State, address.Id));
		#endregion
	}
}
