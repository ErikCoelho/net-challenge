using MediatR;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser;

public record Request(Guid Id, string UpdatedFirstName, string UpdatedLastName, string UpdatedEmail) : IRequest<Response>;
