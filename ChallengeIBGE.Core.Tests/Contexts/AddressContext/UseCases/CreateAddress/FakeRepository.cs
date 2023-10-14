using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.CreateAddress;

public class FakeRepository : IRepository
{
    private readonly Address _address = new("Floripa", "SC", 9999999);
    public Task<bool> AnyAsync(int id, CancellationToken cancellationToken)
    {
        if(id == _address.Id)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public Task<bool> SaveAsync(Address address, CancellationToken cancellationToken)
    {
        if(address is null)
            return Task.FromResult(false);

        return Task.FromResult(true);

    }
}
