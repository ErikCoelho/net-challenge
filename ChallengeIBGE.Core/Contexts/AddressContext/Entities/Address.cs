using ChallengeIBGE.Core.Contexts.SharedContext.Entity;

namespace ChallengeIBGE.Core.Contexts.AddressContext.Entities;

public class Address : Entity
{
    public Address(string city, string state, int ibgeCode)
    {
        City = city;
        State = state;
        IbgeCode = ibgeCode;
    }
    public string City { get; private set; }
    public string State { get; private set; }
    public int IbgeCode { get; private set; }

    public void UpdateCity(string city) => City = city;
    public void UpdateState(string state) => State = state;
    public void UpdateIbgeCode(int ibgeCode) => IbgeCode = ibgeCode;
}
