using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.UpdateAddress;

public class FakeRepository : IRepository
{
    private readonly Address _address = new("Floripa", "SC", 9999999);
    public Task<Address?> GetAddressByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id == _address.Id)
            return Task.FromResult<Address?>(_address);

        return Task.FromResult<Address?>(null);
    }

    public Task<bool> SaveAsync(Address address, CancellationToken cancellationToken)
    {
        if (address is null)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }
}
