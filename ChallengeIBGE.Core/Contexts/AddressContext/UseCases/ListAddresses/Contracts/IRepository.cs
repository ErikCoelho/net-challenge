using ChallengeIBGE.Core.Contexts.AddressContext.Entities;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;

public interface IRepository
{
    Task<Address?> GetAddressByCity(string city, CancellationToken cancellationToken);
    Task<Address?> GetAddressById(int id, CancellationToken cancellationToken);
    Task<Address?> GetAddressByState(string state, CancellationToken cancellationToken);
}
