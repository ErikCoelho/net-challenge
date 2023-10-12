using Flunt.Notifications;
using Flunt.Validations;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsGreaterOrEqualsThan(request.City, 2, "City", "City must have 2 or more characters.")
        .IsLowerOrEqualsThan(request.City, 30, "City", "City must have a maximum of 30 characters.")
        .IsGreaterOrEqualsThan(request.State, 2, "State", "State must have 2 or more characters.")
        .IsLowerOrEqualsThan(request.State, 30, "State", "State must have a maximum of 30 characters.")
        .IsGreaterOrEqualsThan(request.IbgeCode, 1, "IbgeCode", "IbgeCode cannot be zero or null");
}
