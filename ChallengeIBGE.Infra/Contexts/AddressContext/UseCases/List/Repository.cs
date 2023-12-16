using ChallengeIBGE.Core;
using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;
using ChallengeIBGE.Infra.SQL.SqlStatements;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.List;

public class Repository : IRepository
{
    public async Task<List<Address>?> GetAddressByCityAsync(string city, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(Configuration.Database.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var sql = AddressSqlStatement.SearchAddressByCity();
        var addresses = await connection.QueryAsync<Address>(sql, new { City = "%" + city + "%"}).ConfigureAwait(false);
        return addresses.ToList();
    }

    public async Task<List<Address>?> GetAddressByIdAsync(int? id, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(Configuration.Database.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var sql = AddressSqlStatement.SearchAddressById();
        var addresses = await connection.QueryAsync<Address>(sql, new { Id = "%" + id + "%"}).ConfigureAwait(false);
        return addresses.ToList();
    }

    public async Task<List<Address>?> GetAddressByStateAsync(string state, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(Configuration.Database.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var sql = AddressSqlStatement.GetAddressByState();
        var addresses = await connection.QueryAsync<Address>(sql, new { State = "%" + state + "%"}).ConfigureAwait(false);
        return addresses.ToList();
    }
}
