using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.AddRoles.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.AddRoles;

public class FakeRepository : IRepository
{
    private readonly Guid customGuid = new("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e");
    private readonly User _user = new("André", "Baltieri", "balta@balta.io", "ABC123abc123");
    private readonly Role _role = new(Guid.NewGuid(), "Admin");


    public Task<Role?> GetRoleByNameAsync(string role, CancellationToken cancellationToken)
    {
        if (role == _role.Name)
            return Task.FromResult<Role?>(_role);

        return Task.FromResult<Role?>(null);
    }

    public Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        if(userId == customGuid)
            return Task.FromResult<User?>(_user);

        return Task.FromResult<User?>(null);
    }

    public Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        if (user != null)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
