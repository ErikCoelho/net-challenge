using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.AddRoles;

public record Request(Guid UserId, string Role) : IRequest<Response>;
