using ChallengeIBGE.Core.Contexts.SharedContext.ValueObjects;
using System.Security.Cryptography;

namespace ChallengeIBGE.Core.Contexts.UserContext.ValueObjects;

public class Password : ValueObject
{
    private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private const string Special = "!@#$%^&*()_+-=[]{};:'\",.<>?/\\|~";

    protected Password() { }

    public Password(string? password = null)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            password = Generate();

        Hash = Hashing(password);
    }

    public bool VerifyHash(string plainTextPassword) => Verify(Hash, plainTextPassword);

    public string Hash { get; set; } = string.Empty;

    public static string Generate(short length = 16, bool includeSpecialChars = true, bool UpperCase = false)
    {
        var chars = includeSpecialChars ? (Valid + Special) : Valid;
        var startRandom = UpperCase ? 26 : 0;
        var index = 0;
        var random = new Random();
        var res = new char[length];

        while (index < length)
            res[index++] = chars[random.Next(startRandom, chars.Length)];

        return new string(res);
    }

    public static string Hashing(string password, short saltSize = 16, short keySize = 32, int iterations = 10000, char splitChar = '.')
    {
        if (string.IsNullOrEmpty(password))
            throw new Exception("Password is null or empty");

        password += Configuration.Secrets.PasswordSaltKey;

        using var algorithms = new Rfc2898DeriveBytes(password, saltSize, iterations, HashAlgorithmName.SHA256);

        var key = Convert.ToBase64String(algorithms.GetBytes(keySize));
        var salt = Convert.ToBase64String(algorithms.Salt);

        return $"{iterations}{splitChar}{salt}{splitChar}{key}";
    }

    private static bool Verify(string hash, string password, short keySize = 32, int iterations = 10000, char splitChar = '.')
    {
        password += Configuration.Secrets.PasswordSaltKey;

        var parts = hash.Split(splitChar, 3);
        if (parts.Length < 3)
            return false;

        var hashIterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        if (hashIterations != iterations)
            return false;

        using var algorithms = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
        var keyCheck = algorithms.GetBytes(keySize);

        return keyCheck.SequenceEqual(key);
    }
}
