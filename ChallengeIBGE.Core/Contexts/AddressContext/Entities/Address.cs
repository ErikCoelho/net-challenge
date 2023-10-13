namespace ChallengeIBGE.Core.Contexts.AddressContext.Entities;

public class Address
{
    public Address() { }
    public Address(string city, string state, int id)
    {
        Id = Id;
        City = city;
        State = state;
    }
    public int Id { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }

    public void UpdateId(int id) => Id = id;
    public void UpdateCity(string city) => City = city;
    public void UpdateState(string state) => State = state;

}
