using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles;

public record Request(Guid UserId, string Role) : IRequest<Response>;
