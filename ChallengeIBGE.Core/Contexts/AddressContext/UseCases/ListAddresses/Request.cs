using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses;

public class Request : IRequest<Response>
{
    private Request() { }

    public int Id { get; private set; }
    public string? City { get; private set; } = string.Empty;
    public string? State { get; private set; } = string.Empty;

    public static Request WithId(int id)
        => new Request { Id = id, City = null, State = null };

    public static Request WithCity(string city)
        => new Request { Id = 0, City = city, State = null };

    public static Request WithState(string state)
        => new Request { Id = 0, City = null, State = state };
}
