using ChallengeIBGE.Core;
using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.DeleteAddress.Contracts;
using ChallengeIBGE.Infra.SQL.SqlStatements;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.Delete;

public class Repository : IRepository
{
    public async Task<bool> DeleteAddressAsync(Address address, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(Configuration.Database.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var sql = AddressSqlStatement.DeleteAddressById();
        var affectedRows = await connection.ExecuteAsync(sql, new { address.Id}).ConfigureAwait(false);
        return affectedRows > 0;
    }

    public async Task<Address?> GetAddressByIdAsync(int id, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(Configuration.Database.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var sql = AddressSqlStatement.GetAddressById();
        var address = await connection.QuerySingleOrDefaultAsync<Address>(sql, new { Id = id}).ConfigureAwait(false);
        return address;
    }
}
