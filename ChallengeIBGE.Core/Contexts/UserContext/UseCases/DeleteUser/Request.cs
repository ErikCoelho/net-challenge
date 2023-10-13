using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser;

public record Request(Guid Id) : IRequest<Response>;
