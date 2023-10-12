using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress;

public record Request(Guid Id, long IbgeCode) : IRequest<Response>;
