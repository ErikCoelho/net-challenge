using ChallengeIBGE.Core.Contexts.AddressContext.Entities;
using ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses.Contracts;
using ChallengeIBGE.Infra.Data;
using Dapper;

namespace ChallengeIBGE.Infra.Contexts.AddressContext.UseCases.List
{
    public class Repository : IRepository
    {
        public async Task<List<Address>> GetAddressByCityAsync(string city, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT * FROM [dbo].[Address] WHERE [City] LIKE @city";
            var parameters = new { city = $"%{city}%" };

            var addresses = await connection.QueryAsync<Address>(sql, parameters).ConfigureAwait(false);

            return addresses.ToList();
        }

        public async Task<List<Address>> GetAddressByIdAsync(int id, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT * FROM [dbo].[Address] WHERE [Id] LIKE @id";
            var parameters = new { id = $"%{id}%" };

            var addresses = await connection.QueryAsync<Address>(sql, parameters).ConfigureAwait(false);

            return addresses.ToList();
        }

        public async Task<List<Address>> GetAddressByStateAsync(string state, CancellationToken cancellationToken)
        {
            using var connection = Database.CreateConnection();
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var sql = "SELECT * FROM [dbo].[Address] WHERE [State] LIKE @state";
            var parameters = new { state = $"%{state}%" };

            var addresses = await connection.QueryAsync<Address>(sql, parameters).ConfigureAwait(false);

            return addresses.ToList();
        }
    }
}
