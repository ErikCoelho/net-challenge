using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.DeleteAddress;

public class FakeRepository : IRepository
{
    private readonly Address _address = new("Floripa", "SC", 9999999);
    public Task<bool> DeleteAddressAsync(Address address, CancellationToken cancellationToken)
    {
        if (address == _address)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public Task<Address?> GetAddressByIdAsync(int id, CancellationToken cancellationToken)
    {
        if (id == _address.Id)
            return Task.FromResult<Address?>(_address);

        return Task.FromResult<Address?>(null);
    }
}
