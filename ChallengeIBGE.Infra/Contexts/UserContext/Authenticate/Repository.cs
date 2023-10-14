using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.UserContext.Authenticate
{
    public class Repository : IRepository
    {
        public async Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT [Id],  [FirstName], [LastName], [Email], [PasswordHash] FROM[dbo].[User] WHERE [Email] = @Email";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@Email", email);

            User? user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { email }).ConfigureAwait(false);

            return user;
        }
    }
}
