using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.AddRoles.Contracts;
using ChallengeIBGE.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.AddRole;

public class Repository : IRepository
{
    private readonly DataContext _context;
    public Repository(DataContext context) => _context = context;

    public async Task<Role?> GetRoleByNameAsync(string role, CancellationToken cancellationToken)
        => await _context.Roles.FirstOrDefaultAsync(x => x.Name == role, cancellationToken);

    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        => await _context.Users.FirstOrDefaultAsync(user => user.Id == userId, cancellationToken);

    public async Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
