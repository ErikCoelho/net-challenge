using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.SearchUser;

public record Request(Guid Id) : IRequest<Response>;
