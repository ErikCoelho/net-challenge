using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser.Contracts;
using ChallengeIBGE.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.Update
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context) => _context = context;

        public async Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task SaveAsync(User user, CancellationToken cancellationToken)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
