using ChallengeIBGE.Core.Contexts.SharedContext.Entity;
using ChallengeIBGE.Core.Contexts.SharedContext.ValueObjects;
using ChallengeIBGE.Core.Contexts.UserContext.ValueObjects;
using System.Text.Json.Serialization;

namespace ChallengeIBGE.Core.Contexts.UserContext.Entities;

public class User : Entity
{
    protected User() { }
    public User(string firstName, string lastName, string email, string? password = null)
    {
        Name = new(firstName, lastName);
        Email = new(email);
        Password = new(password);
    }
    public User(Name name, Email email, string? password = null)
    {
        Name = name;
        Email = email;
        Password = new Password(password);
    }

    public Name Name { get; private set; } = null!;
    public Email Email{ get; private set; } = null!;
    public Password Password { get; private set; } = null!;

    [JsonIgnore]
    public List<Role> Roles { get; set; } = new();

    public void UpdateName(string firstName, string lastName)
    {
        Name.FirstName = firstName;
        Name.LastName = lastName;
    }

    public void UpdateEmail(string email)
        => Email.Address = email;

    public void AddRole(Role role)
        => Roles.Add(role);

    public void RemoveRole(Role role)
        => Roles.Remove(role);
}