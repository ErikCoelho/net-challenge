using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.Delete
{
    public class Repository : IRepository
    {
        public async Task<bool> DeleteUserAsync(User user, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "DELETE FROM [dbo].[User] WHERE [Id] = @Id";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@Id", user.Id);

            int affectedRows = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
            return affectedRows > 0;
        }

        public async Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT [Id], [FirstName], [LastName], [Email], [Password] FROM [dbo].[User] WHERE [Id] = @id";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);

            User? user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { id }).ConfigureAwait(false);

            return user;
        }
    }
}
