using ChallengeIBGE.Core.Contexts.AddressContext.Entities;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;

public interface IRepository
{
    Task<List<Address>?> GetAddressByCityAsync(string city, CancellationToken cancellationToken);
    Task<List<Address>?> GetAddressByIdAsync(int id, CancellationToken cancellationToken);
    Task<List<Address>?> GetAddressByStateAsync(string state, CancellationToken cancellationToken);
}
