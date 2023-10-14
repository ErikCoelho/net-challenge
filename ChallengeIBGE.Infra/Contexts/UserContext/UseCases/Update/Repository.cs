using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.Update
{
    internal class Repository : IRepository
    {
        public async Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT [Id], [FirstName], [LastName], [Email], [Password] FROM[dbo].[User] WHERE [Id] = @id";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", id);

            User? user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { id }).ConfigureAwait(false);

            return user;
        }

        public async Task<bool> SaveAsync(User user, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "INSERT INTO [dbo].[User] ([Id], [FirstName], [LastName], [Email], [Password]) VALUES (@Id, @FirstName, @LastName, @Email, @Password)";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@FirstName", user.Name.FirstName);
            command.Parameters.AddWithValue("@LastName", user.Name.LastName);
            command.Parameters.AddWithValue("@Email", user.Email.Address);

            int affectedRows = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
            return affectedRows > 0;
        }
    }
}
