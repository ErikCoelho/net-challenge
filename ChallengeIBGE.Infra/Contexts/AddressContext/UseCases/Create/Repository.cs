﻿using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.CreateAddress.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.Create
{
    public class Repository : IRepository
    {
        public async Task<bool> AnyAsync(int ibgeCode, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT 1 FROM [dbo].[Address] WHERE [IbgeCode] = @IbgeCode";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@IbgeCode", ibgeCode);

            object result = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);

            return result != null;
        }

        public async Task SaveAsync(Address address, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "INSERT INTO [dbo].[Address] ([ibgeCode], [state], [city]) VALUES (@ibgeCode, @state, @city)";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@IbgeCode", address.IbgeCode);
            command.Parameters.AddWithValue("@State", address.State);
            command.Parameters.AddWithValue("@City", address.City);

            await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}