using ChallengeIBGE.Core.Contexts.AddressContext.Entities;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress.Contracts;

public interface IRepository
{
    Task<bool> DeleteAddressAsync(Address address, CancellationToken cancellationToken);
    Task<Address?> GetAddressByIdAsync(int id, CancellationToken cancellationToken);
}
