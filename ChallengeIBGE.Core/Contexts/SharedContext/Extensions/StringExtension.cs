using System.Text;

namespace ChallengeIBGE.Core.Contexts.SharedContext.Extensions;

public static class StringExtension
{
    public static string ToBase64(this string value) => Convert.ToBase64String(Encoding.ASCII.GetBytes(value));
}