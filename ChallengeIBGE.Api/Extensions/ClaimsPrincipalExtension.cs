using ChallengeIBGE.Core.Contexts.SharedContext.ValueObjects;
using System.Security.Claims;

namespace ChallengeIBGE.Api.Extensions;

public static class ClaimsPrincipalExtension
{
    public static string Id(this ClaimsPrincipal user)
        => user.Claims.FirstOrDefault(user => user.Type == "Id")?.Value ?? string.Empty;

    public static string Email(this ClaimsPrincipal user)
        => user.Claims.FirstOrDefault(user => user.Type == ClaimTypes.Email)?.Value ?? string.Empty;
}
