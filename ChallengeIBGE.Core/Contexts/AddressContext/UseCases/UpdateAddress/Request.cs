using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress;

public record Request(int Id, string City, string State) : IRequest<Response>;
