namespace ChallengeIBGE.Core.Contexts.SharedContext.Entity;

public abstract class Entity
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; set; }

    public bool Equals(Guid otherId) => Id == otherId;
    public override int GetHashCode() => Id.GetHashCode();
}
