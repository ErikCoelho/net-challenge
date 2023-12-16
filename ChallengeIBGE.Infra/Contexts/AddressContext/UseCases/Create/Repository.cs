using ChallengeIBGE.Core;
using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts;
using ChallengeIBGE.Infra.SQL.SqlStatements;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.Create;

public class Repository : IRepository
{
    public async Task<bool> AnyAsync(int id, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(Configuration.Database.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var sql = AddressSqlStatement.GetAddressById();
        int count = await connection.ExecuteScalarAsync<int>(sql, new { id }).ConfigureAwait(false);
        return count > 0;
    }

    public async Task<bool> SaveAsync(Address address, CancellationToken cancellationToken)
    {
        await using var connection = new SqlConnection(Configuration.Database.ConnectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        var sql = AddressSqlStatement.CreateAddress();
        var affectedRows = await connection.ExecuteAsync(sql, new { Id = address.Id, address.State, address.City}).ConfigureAwait(false);
        return affectedRows > 0;
    }
}