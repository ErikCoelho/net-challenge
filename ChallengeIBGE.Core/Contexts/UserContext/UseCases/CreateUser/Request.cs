using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser;

public record Request(string FirstName, string LastName, string Email, string Password = null!) : IRequest<Response>;
