using Flunt.Notifications;
using Flunt.Validations;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsGreaterOrEqualsThan(request.UpdatedFirstName, 3, "FirstName", "First name must be at least 3 characters long. Please provide a valid first name to proceed.")
        .IsLowerOrEqualsThan(request.UpdatedFirstName, 40, "FirstName", "First name cannot exceed 40 characters. Please provide a valid first name with a maximum of 40 characters to proceed.")
        .IsGreaterOrEqualsThan(request.UpdatedLastName, 3, "LastName", "Last name must be at least 3 characters long. Please provide a valid last name to proceed.")
        .IsLowerOrEqualsThan(request.UpdatedLastName, 80, "LastName", "Last name cannot exceed 80 characters. Please provide a valid last name with a maximum of 80 characters to proceed")
        .IsEmail(request.UpdatedEmail, "Email", "The provided email address is not valid. Please enter a valid email address to proceed.");
}
