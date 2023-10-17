using MediatR;

namespace ChallengeIBGE.Core.Contexts.AddressContext.UseCases.ListAddresses;

public class Request : IRequest<Response>
{
    public Request(int? id, string? city, string? state)
    { 
        Id = id;
        City = city;
        State = state;
    }

    public int? Id { get; private set; }
    public string? City { get; private set; } = string.Empty;
    public string? State { get; private set; } = string.Empty;

    public static Request WithId(int id)
        => new Request(id, null, null);

    public static Request WithCity(string city)
        => new Request(0, city, null);

    public static Request WithState(string state)
        => new Request(0, null, state);
}
