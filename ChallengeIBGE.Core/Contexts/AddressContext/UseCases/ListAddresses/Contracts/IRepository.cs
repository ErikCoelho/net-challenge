using ChallengeIBGE.Core.Contexts.AddressContext.Entities;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;

public interface IRepository
{
    Task<List<Address>?> GetAddressByCity(string city, CancellationToken cancellationToken);
    Task<List<Address>?> GetAddressById(int id, CancellationToken cancellationToken);
    Task<List<Address>?> GetAddressByState(string state, CancellationToken cancellationToken);
}
