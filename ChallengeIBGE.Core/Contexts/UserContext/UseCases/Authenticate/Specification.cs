using Flunt.Notifications;
using Flunt.Validations;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsEmail(request.Email, "Email", "Invalid Email")
        .IsGreaterOrEqualsThan(request.Password, 12, "Password", "Password requires at least 12 characters.")
        .IsLowerOrEqualsThan(request.Password, 128, "Password", "Password maximum length is 128 characters.");
}
