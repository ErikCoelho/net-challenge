namespace ChallengeIBGE.Core.Contexts.UserContext.Entities;

public class Role
{
    public string Name { get; set; } = string.Empty;
    public List<User> Users { get; set; } = new();
}
