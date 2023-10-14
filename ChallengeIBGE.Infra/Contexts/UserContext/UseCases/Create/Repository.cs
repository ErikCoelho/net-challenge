using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Contexts.UserContext.UseCases.Create
{
    public class Repository : IRepository
    {
        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT COUNT(1) FROM [dbo].[User] WHERE [email] = @email";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@email", email);

            int count = await connection.ExecuteScalarAsync<int>(sql, new { email }).ConfigureAwait(false);
            return count > 0;
        }

        public async Task<bool> SaveAsync(User user, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "INSERT INTO [dbo].[User] ([Id], [FirstName], [LastName], [Email], [PasswordHash]) VALUES (@Id, @Name, @Email, @PasswordHash)";

            using var command = (SqlCommand)connection.CreateCommand();
            command.CommandText = sql;
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Name", user.Name.ToString());
            command.Parameters.AddWithValue("@Email", user.Email.Address);
            command.Parameters.AddWithValue("@PasswordHash", user.Password);
            
            int affectedRows = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
            return affectedRows > 0;
        }
    }
}