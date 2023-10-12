using ChallengeIBGE.Core.Contexts.AddressContext.Entities;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(int id, CancellationToken cancellationToken);
    Task SaveAsync(Address address, CancellationToken cancellationToken);
}
