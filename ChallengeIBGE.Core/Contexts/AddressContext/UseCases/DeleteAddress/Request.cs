using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress;

public record Request(Guid Id, int IbgeCode) : IRequest<Response>;
