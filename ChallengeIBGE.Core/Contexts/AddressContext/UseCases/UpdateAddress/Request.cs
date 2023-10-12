using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress;

public record Request(Guid Id, string UpdatedCity, string UpdatedState, int UpdatedIbgeCode) : IRequest<Response>;
