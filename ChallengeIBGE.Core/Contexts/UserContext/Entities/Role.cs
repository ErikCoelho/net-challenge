using ChallengeIBGE.Core.Contexts.SharedContext.Entity;

namespace ChallengeIBGE.Core.Contexts.UserContext.Entities;

public class Role : Entity
{
    public string Name { get; set; } = string.Empty;
    public List<User> Users { get; set; } = new();
}
