using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress;

public record Request(int Id) : IRequest<Response>;
