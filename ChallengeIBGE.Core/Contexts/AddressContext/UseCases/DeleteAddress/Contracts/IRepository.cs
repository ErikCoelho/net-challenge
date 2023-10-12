using ChallengeIBGE.Core.Contexts.AddressContext.Entities;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress.Contracts;

public interface IRepository
{
    void DeleteAddress(Address? address, CancellationToken cancellationToken);
    Task<Address?> GetAddressByIdAsync(int id, CancellationToken cancellationToken);
    Task SaveAsync(CancellationToken cancellationToken);
}
