using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate;

public record Request(string Email, string Password) : IRequest<Response>;
