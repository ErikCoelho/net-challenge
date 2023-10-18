using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.SearchUser.Contracts;
using ChallengeIBGE.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.SearchUser;

public class Repository : IRepository
{
    private readonly DataContext _context;
    public Repository(DataContext context) => _context = context;
    public async Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
        => await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
}