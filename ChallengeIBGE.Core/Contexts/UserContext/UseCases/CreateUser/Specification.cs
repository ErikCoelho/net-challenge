using Flunt.Notifications;
using Flunt.Validations;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser;

public static class Specification
{
    public static Contract<Notification> Validate(Request request) => new Contract<Notification>()
        .Requires()
        .IsGreaterOrEqualsThan(request.FirstName, 3, "FirstName", "First name must be at least 3 characters long. Please provide a valid first name to proceed.")
        .IsLowerOrEqualsThan(request.FirstName, 40, "FirstName", "First name cannot exceed 40 characters. Please provide a valid first name with a maximum of 40 characters to proceed.")
        .IsGreaterOrEqualsThan(request.LastName, 3, "LastName", "Last name must be at least 3 characters long. Please provide a valid last name to proceed.")
        .IsLowerOrEqualsThan(request.LastName, 80, "LastName", "Last name cannot exceed 80 characters. Please provide a valid last name with a maximum of 80 characters to proceed")
        .IsEmail(request.Email, "Email", "The provided email address is not valid. Please enter a valid email address to proceed.")
        .IsGreaterOrEqualsThan(request.Password, 8, "Password", "Password must be at least 8 characters long. Please choose a password that meets this minimum requirement to proceed.");
}
