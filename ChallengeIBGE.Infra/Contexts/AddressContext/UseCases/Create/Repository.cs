using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.Create
{
    public class Repository : IRepository
    {
        public async Task<bool> AnyAsync(int id, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT COUNT(1) FROM [dbo].[Address] WHERE [id] = @id";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);

            int count = await connection.ExecuteScalarAsync<int>(sql, new { id }).ConfigureAwait(false);
            return count > 0;
        }

        public async Task<bool> SaveAsync(Address address, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SET IDENTITY_INSERT Address ON;" +
                      "INSERT INTO [dbo].[Address] ([id], [state], [city]) VALUES (@id, @state, @city)" +
                      "SET IDENTITY_INSERT Address OFF;";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", address.Id);
            command.Parameters.AddWithValue("@state", address.State);
            command.Parameters.AddWithValue("@city", address.City);

            int affectedRows = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
            return affectedRows > 0;
        }
    }
}