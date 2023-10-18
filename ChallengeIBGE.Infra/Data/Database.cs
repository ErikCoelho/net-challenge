using Microsoft.Data.SqlClient;

namespace ChallengeIBGE.Infra.Data;

public static class Database
{
    public static string ConnectionString { get; set; } = null!;

    public static SqlConnection CreateConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}