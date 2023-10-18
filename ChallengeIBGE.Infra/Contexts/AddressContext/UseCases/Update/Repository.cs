using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.UpdateAddress.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.Update;

public class Repository : IRepository
{
    public async Task<Address?> GetAddressByIdAsync(int id, CancellationToken cancellationToken)
    {
        using var connection = Database.CreateConnection();
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var sql = "SELECT [Id], [State], [City] FROM[dbo].[Address] WHERE [Id] = @id";

        using var command = (SqlCommand)connection.CreateCommand();
        command.CommandText = sql;
        command.Parameters.AddWithValue("@id", id);

        Address? address = await connection.QuerySingleOrDefaultAsync<Address>(sql, new { id }).ConfigureAwait(false);

        return address;
    }

    public async Task<bool> SaveAsync(Address address, CancellationToken cancellationToken)
    {
        using var connection = Database.CreateConnection();
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var sql = "UPDATE [dbo].[Address] SET [State] = @State, [City] = @City WHERE [Id] = @Id";

        using var command = (SqlCommand)connection.CreateCommand();
        command.CommandText = sql;
        command.Parameters.AddWithValue("@Id", address.Id);
        command.Parameters.AddWithValue("@State", address.State);
        command.Parameters.AddWithValue("@City", address.City);

        int affectedRows = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        return affectedRows > 0;
    }
}
