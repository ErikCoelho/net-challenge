using ChallengeIBGE.Core.Contexts.AddressContext.Entities;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress.Contracts;

public interface IRepository
{
    Task<Address?> GetAddressByIdAsync(Guid id, CancellationToken cancellationToken);
    Task SaveAsync(Address address, CancellationToken cancellationToken);
}
