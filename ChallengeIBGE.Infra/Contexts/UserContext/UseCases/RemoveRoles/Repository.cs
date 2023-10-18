using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles.Contracts;
using ChallengeIBGE.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.RemoveRoles;

public class Repository : IRepository
{
    private readonly DataContext _context;
    public Repository(DataContext context)
        =>  _context = context;

    public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
        => await _context.Users.Include(e => e.Roles).FirstOrDefaultAsync(e => e.Id == userId, cancellationToken);
    public async Task<Role?> GetRoleByNameAsync(string role, CancellationToken cancellationToken)
      => await _context.Roles.FirstOrDefaultAsync(x => x.Name == role, cancellationToken);

    public async Task RemoveRoleFromUserAsync(User? user, string role, CancellationToken cancellationToken)
    {
        if (user != null)
        {
            var roleToRemove = user.Roles.FirstOrDefault(r => r.Name == role);
            if (roleToRemove != null)
            {
                user.Roles.Remove(roleToRemove);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
