using Flunt.Notifications;
using Flunt.Validations;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires();
}
