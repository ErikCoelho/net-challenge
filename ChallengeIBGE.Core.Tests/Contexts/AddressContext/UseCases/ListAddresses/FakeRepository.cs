using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.AddressContext.UseCases.ListAddresses;

public class FakeRepository : IRepository
{
    private readonly List<Address?> _addresses = new() 
    { 
        new("Floripa", "SC", 9999999),
        new("Balneario Camboriu", "SC", 8888888),
        new("Curitiba", "PR", 7777777)
    };
        
        
    public Task<List<Address>?> GetAddressByCityAsync(string city, CancellationToken cancellationToken)
    {
        List<Address>? listCities = new();
        foreach(var address in _addresses)
        {
            if (city == address?.City)
                listCities.Add(address);
        }

        if(listCities.Count > 0)
        {
            var list = Task.FromResult(listCities);
            return list!;
        }

        return Task.FromResult<List<Address>?>(null);
    }

    public Task<List<Address>?> GetAddressByIdAsync(int? id, CancellationToken cancellationToken)
    {
        List<Address>? listCities = new();
        foreach (var address in _addresses)
        {
            if (id == address?.Id)
                listCities.Add(address!);
        }

        if (listCities.Count > 0)
        {
            var list = Task.FromResult(listCities);
            return list!;
        }

        return Task.FromResult<List<Address>?>(null);
    }

    public Task<List<Address>?> GetAddressByStateAsync(string state, CancellationToken cancellationToken)
    {
        List<Address>? listCities = new();
        foreach (var address in _addresses)
        {
            if (state == address?.State)
                listCities.Add(address);
        }

        if (listCities.Count > 0)
        {
            var list = Task.FromResult(listCities);
            return list!;
        }

        return Task.FromResult<List<Address>?>(null);
    }
}
