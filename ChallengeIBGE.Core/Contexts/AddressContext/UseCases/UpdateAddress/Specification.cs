using Flunt.Notifications;
using Flunt.Validations;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsGreaterOrEqualsThan(request.UpdatedCity, 2, "City", "City must have 2 or more characters.")
        .IsLowerOrEqualsThan(request.UpdatedCity, 30, "City", "City must have a maximum of 30 characters.")
        .IsGreaterOrEqualsThan(request.UpdatedState, 2, "State", "State must have 2 or more characters.")
        .IsLowerOrEqualsThan(request.UpdatedState, 30, "State", "State must have a maximum of 30 characters.")
        .IsGreaterOrEqualsThan(request.UpdatedIbgeCode, 1, "IbgeCode", "IbgeCode cannot be zero or null");
}
