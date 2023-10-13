﻿using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.Read
{
    public class Repository
    {
        public async Task<Address?> GetAddressByIdAsync(int id, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT [Id], [State], [City] FROM[dbo].[Address] WHERE [Id] = @id";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);

            Address address = await connection.QuerySingleOrDefaultAsync<Address>(sql, new { id }).ConfigureAwait(false);

            return address;
        }
    }
}