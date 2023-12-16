namespace ChallengeIBGE.Infra.SQL.SqlStatements;

public static class AddressSqlStatement
{
    public static string SearchAddressByCity()
    {
        var statement = @"SELECT Id, State, City FROM Address WHERE City LIKE @city";
        return statement;
    }

    public static string SearchAddressById()
    {
        var statement = @"SELECT Id, State, City FROM Address WHERE Id LIKE @id";
        return statement;
    }
    
    public static string GetAddressByState()
    {
        var statement = @"SELECT Id, State, City FROM Address WHERE State LIKE @state";
        return statement;
    }

    public static string DeleteAddressById()
    {
        var statement = @"DELETE FROM Address WHERE Id = @id";
        return statement;
    }
    
    public static string GetAddressById()
    {
        var statement = @"SELECT Id, State, City FROM Address WHERE Id = @id";
        return statement;
    }

    public static string UpdateAddressById()
    {
        var statement = @"UPDATE Address SET State = @State, City = @City WHERE Id = @Id";
        return statement;
    }

    public static string CreateAddress()
    {
        var statement = @"SET IDENTITY_INSERT Address ON;
                           INSERT INTO Address(id, state, city) VALUES (@id, @state, @city)
                           SET IDENTITY_INSERT Address OFF";
        return statement;
    }
}