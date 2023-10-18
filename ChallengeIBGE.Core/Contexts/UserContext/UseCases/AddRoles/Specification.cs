using Flunt.Notifications;
using Flunt.Validations;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.AddRoles;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsGreaterOrEqualsThan(request.Role, 3, "Role", "Role must be at least 3 characters long.")
        .IsLowerOrEqualsThan(request.Role, 30, "Role", "Role must have maximum 30 characters.");
}
