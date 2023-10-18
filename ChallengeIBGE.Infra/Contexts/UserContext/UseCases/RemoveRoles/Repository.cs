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

    public async Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRoleFromEmployeeAsync(Guid idEmployee, string role, CancellationToken cancellationToken)
    {
        var employee = await _context.Users.Include(e => e.Roles)
            .FirstOrDefaultAsync(e => e.Id == idEmployee, cancellationToken);
        if (employee != null)
        {
            var roleToRemove = employee.Roles.FirstOrDefault(r => r.Name == role);
            if (roleToRemove != null)
            {
                employee.Roles.Remove(roleToRemove);
            }
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
